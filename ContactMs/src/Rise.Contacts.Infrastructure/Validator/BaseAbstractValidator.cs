using FluentValidation;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Infrastructure.Validator
{
    public abstract class BaseAbstractValidator<T> : AbstractValidator<T> where T : class, new()
    {
        protected readonly ContactContext _context;

        public BaseAbstractValidator(ContactContext context)
        {
            _context = context;
        }
    }
}
