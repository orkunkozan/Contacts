using MediatR;
using Microsoft.EntityFrameworkCore;
using Rise.Contacts.Business.Handlers.Contact.Models; 
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Contact.Queries
{
    public class GetPersonContactsQuery : IRequest<List<ContactDto>>
    {  
        public long PersonId { get; set; }
        public class GetPersonsQueryHandler : IRequestHandler<GetPersonContactsQuery, List<ContactDto>>
        {
            private readonly ContactContext _context;
            public GetPersonsQueryHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<List<ContactDto>> Handle(GetPersonContactsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Contacts
                    .Where(w=>w.PersonId== request.PersonId)
                    .Select(s => new ContactDto
                    {
                        ContactType = s.ContactType,
                        Id = s.Id,
                        Content = s.Content 
                    }).ToListAsync(cancellationToken);
                return result;
            }
        }
    }
}
