using MediatR;
using Microsoft.EntityFrameworkCore;
using Rise.Contacts.Business.Handlers.Person.Models;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Person.Commands
{
    public class AddPersonCommand : PersonDto , IRequest<Unit>
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
                var result = await _context.Persons
                    .Select(s => new PersonDto
                    {
                        Company = s.Company, 
                        Id = s.Id,
                        Name = s.Name,
                        SurName = s.SurName
                    }).ToListAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
