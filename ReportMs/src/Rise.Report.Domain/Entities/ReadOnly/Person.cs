using Rice.Core.Context.Abstraction;
using Rice.Core.Context.Entity;

namespace Rise.Report.Domain.Entities.ReadOnly
{
    public class Person : IEntity , IReadOnlyEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
