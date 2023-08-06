using Microsoft.EntityFrameworkCore;
using Rice.Core.Context.Abstraction;
using Rice.Core.SubServices.Abstraction;

namespace Rice.Core.SubServices
{
    public class BaseCrudSubServices<TContext, TEntity> : BaseSubServices<TContext>, ISubscribeEntityWriteOpreation<TEntity>
        where TContext : DbContext, ISubscribeDbContext
        where TEntity : class, IReadOnlyEntity
    {
        public BaseCrudSubServices(ISubscribeDbContext context) : base(context)
        {
        }

        public virtual async Task Added(TEntity entity)
        {
            var hasRecord = await _context.Set<TEntity>().AnyAsync(w => w.Id == entity.Id);
            if (!hasRecord)
            {
                try
                {
                    await _context.Set<TEntity>().AddAsync(entity);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public virtual async Task Updated(TEntity entity)
        {
            try
            {
                var hasRecord = await _context.Set<TEntity>().AnyAsync(w => w.Id == entity.Id);
                if (!hasRecord)
                {
                    await _context.Set<TEntity>().AddAsync(entity);
                }
                else
                {
                    _context.Update(entity);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public virtual async Task Deleted(TEntity entity)
        {
            try
            {
                var hasRecord = await _context.Set<TEntity>().AnyAsync(w => w.Id == entity.Id);
                if (!hasRecord)
                {
                    return;
                }
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
