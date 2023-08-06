using FluentValidation;
using Rise.Contacts.Business.Handlers.Contact.Commands; 
using Rise.Contacts.Infrastructure.DataAccess.Contexts;
using Rise.Contacts.Infrastructure.Validator;

namespace Rise.Contacts.Business.Handlers.Contact.ValidationRules
{
    public class AddContactValidator : BaseAbstractValidator<AddContactCommand>
    {
        public AddContactValidator(ContactContext context) : base(context)
        { 
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.ContactType).IsInEnum();

            RuleFor(x => x).Must((x) =>
            {
                return _context.Persons.Any(a => a.Id == x.PersonId);

            }).WithMessage("Kişi kaydı sistemde bulunamadı !");
        } 
    }
}
