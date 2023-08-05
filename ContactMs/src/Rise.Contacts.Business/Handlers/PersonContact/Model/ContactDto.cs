using Rice.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rice.Core.Extensions;

namespace Rise.Contacts.Business.Handlers.PersonContact.Model
{
    public class ContactDto
    {
        public long Id { get; set; }
        public ContactType ContactType { get; set; } 
        public string ContactTypeText => ContactType.GetDescription(); 
        public string Content { get; set; } = string.Empty;
    }
}
