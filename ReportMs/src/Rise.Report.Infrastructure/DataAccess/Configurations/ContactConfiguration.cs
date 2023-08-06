using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rice.Core.Context.Configuration;
using Rise.Report.Domain.Entities.ReadOnly;

namespace Rise.Report.Infrastructure.DataAccess.Configurations
{
    public class ContactConfiguration : BaseConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ContactType).IsRequired();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PersonId).IsRequired();


            builder.HasOne(x => x.Person).WithMany(x => x.Contacts)
                .HasForeignKey(x => x.PersonId);

        }
    }
}
