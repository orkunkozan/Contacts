using Rice.Core.Context.Abstraction;
using Rice.Core.Context.Entity;

namespace Rise.Contacts.Domain.Entities.Owner
{
    public class Person : IEntity , IPublishEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
