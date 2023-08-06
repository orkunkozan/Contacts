using FluentValidation;
using Rise.Contacts.Business.Handlers.Contact.Commands; 
using Rise.Contacts.Infrastructure.DataAccess.Contexts;
using Rise.Contacts.Infrastructure.Validator;

namespace Rise.Contacts.Business.Handlers.Contact.ValidationRules
{
    public class DeleteContactValidator : BaseAbstractValidator<DeleteContactCommand>
    {
        public DeleteContactValidator(ContactContext context) : base(context)
        { 
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x).Must((x) =>
            {
              return _context.Contacts.Any(a => a.Id == x.Id);
               
            }).WithMessage("Girilen ID sistemde bulunamadı !");
            RuleFor(x => x).Must((x) => x.Id > 0).WithMessage("Lütfen geçerli bir ID gönderiniz !");
        }
    }
}
