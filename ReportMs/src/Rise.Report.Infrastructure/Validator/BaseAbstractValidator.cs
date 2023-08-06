using FluentValidation;
using Rise.Report.Infrastructure.DataAccess.Contexts;

namespace Rise.Report.Infrastructure.Validator
{
    public abstract class BaseAbstractValidator<T> : AbstractValidator<T> where T : class, new()
    {
        protected readonly ReportContext _context;

        public BaseAbstractValidator(ReportContext context)
        {
            _context = context;
        }
    }
}
