using Rise.Contacts.Business.Handlers.Person.Commands;
using Rise.Contacts.Infrastructure.Validator;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;
using FluentValidation; 

namespace Rise.Contacts.Business.Handlers.Person.ValidationRules
{
    public class DeletePersonValidator : BaseAbstractValidator<DeletePersonCommand>
    {
        public DeletePersonValidator(ContactContext context) : base(context)
        { 
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x).Must((x) =>
            {
              return _context.Persons.Any(a => a.Id == x.Id);
               
            }).WithMessage("Girilen ID sistemde bulunamadı !");
            RuleFor(x => x).Must((x) => x.Id > 0).WithMessage("Lütfen geçerli bir ID gönderiniz !");
        }
    }
}
