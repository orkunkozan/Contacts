using MediatR;
using Rise.Report.Business.Handlers.Report.Models;
using Rise.Report.Infrastructure.DataAccess.Contexts;

namespace Rise.Report.Business.Handlers.Report.Queries
{
    public class GetLocationReportQuery : IRequest<List<LocationReportDto>>
    {
        public long ReportId { get; set; }
        public class GetLocationReportQueryHandler : IRequestHandler<GetLocationReportQuery, List<LocationReportDto>>
        {
            private readonly ReportContext _context;
            private readonly IMediator _mediator;
            public GetLocationReportQueryHandler(ReportContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<List<LocationReportDto>> Handle(GetLocationReportQuery request, CancellationToken cancellationToken)
            {

                var reportData = await _mediator.Send(new GetReportDetailQuery
                {
                    ReportId = request.ReportId
                },cancellationToken);

                if (reportData == null)
                {
                    return new();
                }

                return (List<LocationReportDto>)reportData;
            }
        }
    }
}
