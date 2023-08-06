using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rise.Contacts.Api.Controllers.Base;
using Rise.Contacts.Business.Handlers.Person.Models;
using Rise.Contacts.Business.Handlers.Person.Queries;

namespace Rise.Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        } 

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)] 
        [HttpGet("getAll")]
        public async Task<IActionResult> GetPersons(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPersonsQuery(), cancellationToken);
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPersonsQuery(), cancellationToken);
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

    }
}
