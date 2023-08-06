using MediatR;
using Microsoft.EntityFrameworkCore;
using Rise.Contacts.Business.Handlers.Person.Models;
using Rise.Contacts.Infrastructure.DataAccess.Contexts;

namespace Rise.Contacts.Business.Handlers.Person.Queries
{
    public class GetPersonsQuery : IRequest<List<PersonDto>>
    {  
        public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonDto>>
        {
            private readonly ContactContext _context;
            public GetPersonsQueryHandler(ContactContext context)
            {
                _context = context;
            }

            public async Task<List<PersonDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Persons
                    .Select(s => new PersonDto
                    {
                        Company = s.Company, 
                        Id = s.Id,
                        Name = s.Name,
                        SurName = s.SurName
                    }).ToListAsync(cancellationToken);
                return result;
            }
        }
    }
}
