using Rise.Contacts.Business.Handlers.Person.Commands;
using Rise.Contacts.Infrastructure.Validator;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;
using FluentValidation;

namespace Rise.Contacts.Business.Handlers.Person.ValidationRules
{
    public class AddPersonValidator : BaseAbstractValidator<AddPersonCommand>
    {
        public AddPersonValidator(ContactContext context) : base(context)
        { 
            RuleFor(x => x.Company).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
        } 
    }
}
