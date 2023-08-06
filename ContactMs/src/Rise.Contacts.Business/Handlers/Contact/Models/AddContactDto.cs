using Rice.Core.Enums;

namespace Rise.Contacts.Business.Handlers.Contact.Models
{
    public class AddContactDto
    { 
        public ContactType ContactType { get; set; } 
        public string Content { get; set; } = string.Empty;
        public long PersonId { get; set; } 

    }
}
