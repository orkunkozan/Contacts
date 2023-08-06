using Rice.Core.Enums;
using Rice.Core.Extensions;

namespace Rise.Contacts.Business.Handlers.Contact.Models
{
    public class ContactDto
    {
        public long Id { get; set; }
        public ContactType ContactType { get; set; }
        public string ContactTypeText => ContactType.GetDescription();
        public string Content { get; set; } = string.Empty;
    }
}
