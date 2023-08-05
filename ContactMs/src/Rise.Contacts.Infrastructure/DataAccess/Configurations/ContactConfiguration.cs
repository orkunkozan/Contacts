using Rise.Contacts.Domain.Entities.Owner;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rice.Core.Context.Configuration;

namespace Rise.Contacts.Infrastructure.DataAccess.Configurations
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
