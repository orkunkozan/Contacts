using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rise.Contacts.Api.Controllers.Base;
using Rise.Contacts.Business.Handlers.Contact.Models;
using Rise.Contacts.Business.Handlers.Contact.Queries;

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



    }
}
