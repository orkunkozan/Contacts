using MediatR;
using Rise.Contacts.Business.Handlers.Contact.Models;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Contact.Commands
{
    public class AddContactCommand : AddContactDto, IRequest<long>
    {
        public class AddContactCommandHandler : IRequestHandler<AddContactCommand, long>
        {
            private readonly ContactContext _context;
            public AddContactCommandHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<long> Handle(AddContactCommand request, CancellationToken cancellationToken)
            {
                var newRecord = new Domain.Entities.Owner.Contact
                {
                    ContactType = request.ContactType,
                    Content = request.Content,
                    PersonId = request.PersonId
                };
                await _context.Contacts.AddAsync(newRecord, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return newRecord.Id; 
            }
        }
    }
}
