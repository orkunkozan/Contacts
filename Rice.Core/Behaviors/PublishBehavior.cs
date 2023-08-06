using FluentValidation;
using MediatR;
using Rice.Core.Context.Abstraction;

namespace Rice.Core.Behaviors
{
    public class PublishBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IProjectContext _context;

        public PublishBehavior(IProjectContext context)
        {
            _context = context;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var handler = await next();
            while (!_context.PublishCompleted)
            {
                // publish complate waiting;
            }
            return handler;
        }
    }
}
