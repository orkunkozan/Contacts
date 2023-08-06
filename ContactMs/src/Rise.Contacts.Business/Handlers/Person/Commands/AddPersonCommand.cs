using MediatR; 
using Rise.Contacts.Business.Handlers.Person.Models;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Person.Commands
{
    public class AddPersonCommand : AddPersonDto, IRequest<Unit>
    {   
        public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Unit >
        {
            private readonly ContactContext _context;
            public AddPersonCommandHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
            {
                await _context.Persons.AddAsync(new Domain.Entities.Owner.Person
                {
                    Company = request.Company,
                    Name = request.Name,
                    SurName = request.SurName
                },cancellationToken); 
                await _context.SaveChangesAsync(cancellationToken); 
                return Unit.Value;  

            }
        }
    }
}
