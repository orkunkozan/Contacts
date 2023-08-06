using Rice.Core.Context.Abstraction;
using Rice.Core.Context.Entity;
using Rice.Core.Enums;

namespace Rise.Contacts.Domain.Entities.Owner
{
    public  class Contact :IEntity , IPublishEntity
    {
        public long Id { get; set; } 
        public ContactType ContactType { get; set; } 
        public string Content { get; set; } 
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
