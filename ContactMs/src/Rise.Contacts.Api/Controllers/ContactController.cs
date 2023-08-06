using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rise.Contacts.Api.Controllers.Base;
using Rise.Contacts.Business.Handlers.Contact.Commands;
using Rise.Contacts.Business.Handlers.Contact.Models;
using Rise.Contacts.Business.Handlers.Contact.Queries;
using Rise.Contacts.Business.Handlers.Person.Commands;

namespace Rise.Contacts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseController
    {
        public ContactController(IMediator mediator) : base(mediator)
        {
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContactDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("getPersonContacts/{personId}")]
        public async Task<IActionResult> GetPersonContacts([FromRoute] long personId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPersonContactsQuery
            {
                PersonId = personId
            }, cancellationToken);
            if (result != null)
            {
                return Ok(result);
            }
            return NoContent();
        }


        /// <summary>
        /// You can add new contact into person.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddContactCommand request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }


        /// <summary>
        /// You can delete contact by Contact ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteContactCommand{ Id = id }, cancellationToken);
            return Ok();
        } 
    }
}
