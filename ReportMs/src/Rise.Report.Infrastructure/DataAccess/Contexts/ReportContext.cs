using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rice.Core.Context;
using Rice.Core.Context.Abstraction;
using Rice.Core.Services.EntityChangeServices;
using Rise.Report.Domain.Entities.ReadOnly;

namespace Rise.Report.Infrastructure.DataAccess.Contexts
{
    public class ReportContext : ProjectDbContext, IMsContext
    {
        public ReportContext(IConfiguration configuration, ICapPublisher capPublisher, IEntityChangeServices entityChangeServices) : 
            base(configuration, capPublisher, entityChangeServices)
        {

        }

        #region Owner

        public DbSet<Domain.Entities.Owner.Report> Reports { get; set; }
        public DbSet<Domain.Entities.Owner.ReportData> ReportDatas { get; set; }

        #endregion


        #region readOnly

        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        #endregion


    }
}
