using MediatR;
using Microsoft.AspNetCore.Mvc; 
using Rise.Report.Api.Controllers.Base;
using Rise.Report.Business.Handlers.Report.Commands;
using Rise.Report.Business.Handlers.Report.Models;
using Rise.Report.Business.Handlers.Report.Queries;

namespace Rise.Report.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        public ReportController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// You can prepare location report
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [HttpPost("prepareLocationReport")]
        public async Task<IActionResult> PrepareLocationReport(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new PrepareLocationReportCommand(),cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// You can get all reports
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReportsDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("getReports")]
        public async Task<IActionResult> GetReports(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetReportsQuery()
             , cancellationToken);
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }


        /// <summary>
        /// You can get complated location report.
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LocationReportDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("getLocationReport/{reportId}")]
        public async Task<IActionResult> GetLocationReport([FromRoute] long reportId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetLocationReportQuery
            {
                ReportId = reportId
            }, cancellationToken);
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

    }
}
