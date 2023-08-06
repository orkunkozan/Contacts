using Rice.Core.Context.Abstraction;
using Rice.Core.Context.Entity;
using Rice.Core.Enums;

namespace Rise.Report.Domain.Entities.ReadOnly
{
    public class Contact : IEntity , IReadOnlyEntity
    {
        public long Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Content { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
