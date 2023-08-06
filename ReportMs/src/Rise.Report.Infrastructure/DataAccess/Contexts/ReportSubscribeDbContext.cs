using DotNetCore.CAP;
using Microsoft.Extensions.Configuration;
using Rice.Core.Context.Abstraction;
using Rice.Core.Services.EntityChangeServices;

namespace Rise.Report.Infrastructure.DataAccess.Contexts
{
    public class ReportSubscribeDbContext : ReportContext , ISubscribeDbContext
    {
        public ReportSubscribeDbContext(IConfiguration configuration, ICapPublisher capPublisher, IEntityChangeServices entityChangeServices) : 
            base(configuration, capPublisher, entityChangeServices)
        {
        } 
    }
}
