using FluentValidation;
using MediatR;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Rice.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validators.Select(e => e.ValidateAsync(context, cancellationToken)));
                var errors = result.Where(w => w.Errors.Count > 0).SelectMany(e => e.Errors).ToArray();
                if (errors.Length > 0)
                {
                    var errorLines = errors.Select(s => s.ErrorMessage).Distinct().Aggregate((current, next) => current + "\n" + next);
                    throw new ValidationException(errorLines);
                }
            }
            return await next();
        }
    }
}
