using DotNetCore.CAP;
using Rice.Core.SubServices;
using Rise.Report.Infrastructure.DataAccess.Contexts;
using Rise.Report.Domain.Entities.ReadOnly;

namespace Rise.Report.Business.SubServices
{
    public class PersonSubServices : BaseCrudSubServices<ReportSubscribeDbContext, Person>
    {
        public PersonSubServices(ReportSubscribeDbContext context) : base(context)
        {
        }

        [CapSubscribe("Rise.Contacts.Domain.Entities.Owner.Person_Added")]
        public override async Task Added(Person entity)
        {
            await base.Added(entity);
        }

        [CapSubscribe("Rise.Contacts.Domain.Entities.Owner.Person_Modified")]
        public override async Task Updated(Person entity)
        {
            await base.Updated(entity);
        }

        [CapSubscribe("Rise.Contacts.Domain.Entities.Owner.Person_Deleted")]
        public override async Task Deleted(Person entity)
        {
            await base.Deleted(entity);
        }
    }
}
