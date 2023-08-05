using MediatR;
using Microsoft.EntityFrameworkCore;
using Rise.Contacts.Business.Handlers.PersonContact.Model;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.PersonContact.Queries
{
    public class GetPersonContactQuery : IRequest<PersonContactDto>
    {
        public long Id { get; set; }

        public class GetPersonContactQueryHandler : IRequestHandler<GetPersonContactQuery, PersonContactDto>
        {
            private readonly ContactContext _context;
            public GetPersonContactQueryHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<PersonContactDto> Handle(GetPersonContactQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Persons.Where(w => w.Id == request.Id).Include(i => i.Contacts)
                    .Select(s => new PersonContactDto
                    {
                        Company = s.Company,
                        Contacts = s.Contacts.Select(ss => new ContactDto
                        {
                            ContactType = ss.ContactType,
                            Content = ss.Content,
                            Id = ss.Id
                        }).ToList(),
                        Id = s.Id,
                        Name = s.Name,
                        SurName = s.SurName
                    }).FirstOrDefaultAsync(cancellationToken);
                return result;
            }
        }
    }
}
