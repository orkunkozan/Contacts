using DotNetCore.CAP;
using Rice.Core.SubServices;
using Rise.Report.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rise.Report.Domain.Entities.ReadOnly;

namespace Rise.Report.Business.SubServices
{
    public class ContactSubServices : BaseCrudSubServices<ReportSubscribeDbContext, Contact>
    {
        public ContactSubServices(ReportSubscribeDbContext context) : base(context)
        {
        }

        [CapSubscribe("Rise.Contacts.Domain.Entities.Owner.Contact_Added")]
        public override async Task Added(Contact entity)
        {
            await base.Added(entity);
        }

        [CapSubscribe("Rise.Contacts.Domain.Entities.Owner.Contact_Modified")]
        public override async Task Updated(Contact entity)
        {
            await base.Updated(entity);
        }

        [CapSubscribe("Rise.Contacts.Domain.Entities.Owner.Contact_Deleted")]
        public override async Task Deleted(Contact entity)
        {
            await base.Deleted(entity);
        }
    }
}
