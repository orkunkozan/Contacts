namespace Rise.Contacts.Business.Handlers.Person.Models
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty; 
    } 
}
