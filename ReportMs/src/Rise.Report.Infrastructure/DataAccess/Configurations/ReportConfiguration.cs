using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rice.Core.Context.Configuration;
using Rice.Core.Enums;

namespace Rise.Report.Infrastructure.DataAccess.Configurations
{
    public class ReportConfiguration : BaseConfiguration<Domain.Entities.Owner.Report>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Owner.Report> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ReportStateType).IsRequired().HasDefaultValue(ReportStateType.Requested.GetHashCode());
            builder.Property(x => x.ReportType).IsRequired();
            builder.Property(x => x.RequestTime).IsRequired();


            builder.HasIndex(i => new { i.RequestTime, i.ReportStateType });
        }
    }
}
