using MediatR;
using Microsoft.EntityFrameworkCore; 
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Person.Commands
{
    public class DeletePersonCommand :  IRequest
    {   
        public long Id { get; set; }
        public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
        {
            private readonly ContactContext _context;
            public DeletePersonCommandHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
            { 
                var record= await _context.Persons.FirstOrDefaultAsync(w => w.Id == request.Id,cancellationToken);
                _context.Persons.Remove(record); 
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
        }
    }
}
