using MediatR;
using Microsoft.EntityFrameworkCore;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Contact.Commands
{
    public class DeleteContactCommand :  IRequest
    {   
        public long Id { get; set; }
        public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
        {
            private readonly ContactContext _context;
            public DeleteContactCommandHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
            { 
                var record= await _context.Contacts.FirstOrDefaultAsync(w => w.Id == request.Id,cancellationToken);
                _context.Contacts.Remove(record); 
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value; 
            }
        }
    }
}
