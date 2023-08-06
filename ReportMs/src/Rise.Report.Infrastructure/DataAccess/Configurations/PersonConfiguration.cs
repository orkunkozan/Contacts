using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rice.Core.Context.Configuration;
using Rise.Report.Domain.Entities.ReadOnly;

namespace Rise.Report.Infrastructure.DataAccess.Configurations
{
    public class PersonConfiguration : BaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Company).IsRequired(false).HasMaxLength(150); 
        }
    }
}
