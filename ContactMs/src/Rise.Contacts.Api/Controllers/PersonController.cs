using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rise.Contacts.Api.Controllers.Base;
using Rise.Contacts.Business.Handlers.Person.Commands;
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

        /// <summary>
        /// you can get all persons data
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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


        /// <summary>
        /// You can add new person
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }


        /// <summary>
        /// You can delete person by person ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> AddPerson([FromRoute] long id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePersonCommand { Id = id }, cancellationToken);
            return Ok();
        }
         
    }
}
