using MediatR;
using Rise.Contacts.Business.Handlers.Person.Models;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Person.Commands
{
    public class AddPersonCommand : AddPersonDto, IRequest<long>
    {
        public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, long>
        {
            private readonly ContactContext _context;
            public AddPersonCommandHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(AddPersonCommand request, CancellationToken cancellationToken)
            {
                var newRecord = new Domain.Entities.Owner.Person
                {
                    Company = request.Company,
                    Name = request.Name,
                    SurName = request.SurName
                };
                await _context.Persons.AddAsync(newRecord,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken); 
                return newRecord.Id;

            }
        }
    }
}
