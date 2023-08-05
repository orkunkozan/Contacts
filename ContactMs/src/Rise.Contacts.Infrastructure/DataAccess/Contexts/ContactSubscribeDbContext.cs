using DotNetCore.CAP;
using Microsoft.Extensions.Configuration;
using Rice.Core.Context.Abstraction;
using Rice.Core.Services.EntityChangeServices;

namespace Rise.Contacts.Infrastructure.DataAccess.Contexts
{
    public class ContactSubscribeDbContext : ContactContext , ISubscribeDbContext
    {
        public ContactSubscribeDbContext(IConfiguration configuration, ICapPublisher capPublisher, IEntityChangeServices entityChangeServices) : 
            base(configuration, capPublisher, entityChangeServices)
        {
        } 
    }
}
