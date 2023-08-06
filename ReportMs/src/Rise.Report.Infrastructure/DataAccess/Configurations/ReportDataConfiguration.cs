using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rice.Core.Context.Configuration;
using Rise.Report.Domain.Entities.Owner; 

namespace Rise.Report.Infrastructure.DataAccess.Configurations
{
    public class ReportDataConfiguration : BaseConfiguration<ReportData>
    {
        public override void Configure(EntityTypeBuilder<ReportData> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.ReportId).IsRequired();
            builder.Property(x => x.Data).IsRequired();

            builder.HasOne(x => x.Report).WithOne(x => x.ReportData).HasForeignKey<ReportData>(e => e.ReportId);
        }
    }
}
