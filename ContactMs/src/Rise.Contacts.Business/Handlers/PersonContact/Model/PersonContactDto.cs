namespace Rise.Contacts.Business.Handlers.PersonContact.Model
{
    public class PersonContactDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public List<ContactDto> Contacts { get; set; } = new();
    } 
}
