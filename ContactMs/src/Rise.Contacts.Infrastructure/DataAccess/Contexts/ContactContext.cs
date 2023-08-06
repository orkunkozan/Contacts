using Rice.Core.Context.Abstraction;
using Rice.Core.Context;
using DotNetCore.CAP;
using Microsoft.Extensions.Configuration;
using Rice.Core.Services.EntityChangeServices;
using Microsoft.EntityFrameworkCore;
using Rise.Contacts.Domain.Entities.Owner;

namespace Rise.Contacts.Infrastructure.DataAccess.Contexts
{
    public class ContactContext : ProjectDbContext, IMsContext 
    {
        public ContactContext(IConfiguration configuration, ICapPublisher capPublisher, IEntityChangeServices entityChangeServices) : 
            base(configuration, capPublisher, entityChangeServices)
        {

        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
