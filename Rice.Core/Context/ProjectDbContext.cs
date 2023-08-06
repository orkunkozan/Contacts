using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Rice.Core.Context.Abstraction;
using Rice.Core.Context.Model;
using Rice.Core.CustomExceptions;
using Rice.Core.Extensions;
using Rice.Core.Services.EntityChangeServices;

namespace Rice.Core.Context
{
    public class ProjectDbContext : DbContext , IProjectContext
    {
        protected readonly IConfiguration _configuration;
        private readonly ICapPublisher _capPublisher;
        private readonly IEntityChangeServices _entityChangeServices;

        public bool PublishCompleted => _publishCompleted;

        private bool _publishCompleted = true;
        public ProjectDbContext(IConfiguration configuration, ICapPublisher capPublisher, IEntityChangeServices entityChangeServices)
        {
            _configuration = configuration;
            _capPublisher = capPublisher;
            _entityChangeServices = entityChangeServices;
        }



        protected DbContextOptions _options;
        public DbContextOptions Options
        {
            get
            {
                return _options;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresContext")));
            }
            _options = optionsBuilder.Options;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var changeTrack = this.ChangeTracker.Entries()
                .Where(c => c.State == EntityState.Added | c.State == EntityState.Modified | c.State == EntityState.Deleted)
                .ToList();
            ChangeTrackControl(changeTrack);
            var changeTrackStates = ChangeTrackStateCalculate(changeTrack);
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            PublishData(changeTrack, changeTrackStates);
            return result;
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            var changeTrack = this.ChangeTracker.Entries()
                .Where(c => c.State == EntityState.Added | c.State == EntityState.Modified | c.State == EntityState.Deleted)
                .ToList();
            ChangeTrackControl(changeTrack);
            var changeTrackStates = ChangeTrackStateCalculate(changeTrack);
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            result.ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    PublishData(changeTrack, changeTrackStates);
                }
            }, cancellationToken).ConfigureAwait(true);

            return result;
        }

        private void ChangeTrackControl(List<EntityEntry> changeTrack)
        {
            if (!(this is ISubscribeDbContext))
            {
                if (changeTrack.Any(a => a.Entity is IReadOnlyEntity))
                {
                    throw new ProjectException("İşlem yaptığınız mikro servis üzerinden bu entity düzenlenemez !");
                }
                _publishCompleted = !changeTrack.Any(a => a.Entity is IPublishEntity);
            }
        }

        private List<ChangeTrackState> ChangeTrackStateCalculate(List<EntityEntry> changeTrack)
        {
            var result = new List<ChangeTrackState>();
            if (changeTrack.Any(a => a.Entity is IPublishEntity))
            {
                var i = 0;

                foreach (var itemChange in changeTrack)
                {
                    result.Add(new ChangeTrackState
                    {
                        Index = i,
                        State = itemChange.State
                    });
                    i++;
                }
            }
            return result;
        }

        private void PublishData(List<EntityEntry> changeTrack, List<ChangeTrackState> changeTrackStates)
        {
            if (!changeTrackStates.Any())
            {
                return;
            }
            try
            {
                var hasTransaction = this.Database.CurrentTransaction != null;
                if (hasTransaction)
                {
                    var changeTrackCopy = new EntityEntry[changeTrack.Count];
                    changeTrack.CopyTo(changeTrackCopy);
                    _entityChangeServices.ChangeEntriesList.Add(new ChangeEntityModel
                    {
                        ChangeTrack = changeTrackCopy,
                        ChangeTrackStates = changeTrackStates
                    });
                    return;
                }

                var i = 0;

                foreach (var itemChange in changeTrack)
                {
                    if (itemChange.Entity is IPublishEntity)
                    {
                        var processName = ((IPublishEntity)itemChange.Entity).GeneratePublishName(changeTrackStates[i].State);
                        try
                        {
                            _capPublisher.Publish(processName, itemChange.Entity);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                    i++;
                }
                _publishCompleted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }
        }
    }
}
