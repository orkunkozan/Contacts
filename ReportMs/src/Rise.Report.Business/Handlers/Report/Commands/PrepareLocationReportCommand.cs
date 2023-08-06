using DotNetCore.CAP;
using MediatR;
using Rice.Core.Const;
using Rice.Core.Enums;
using Rise.Report.Infrastructure.DataAccess.Contexts;

namespace Rise.Report.Business.Handlers.Report.Commands
{
    public class PrepareLocationReportCommand :  IRequest<long>
    {
        public class PrepareLocationReportCommandHandler : IRequestHandler<PrepareLocationReportCommand, long>
        {
            private readonly ReportContext _context;
            private readonly ICapPublisher _capPublisher;
            public PrepareLocationReportCommandHandler(ReportContext context, ICapPublisher capPublisher)
            {
                _context = context;
                _capPublisher = capPublisher;
            }

            public async Task<long> Handle(PrepareLocationReportCommand request, CancellationToken cancellationToken)
            {
                var reportRecord = new Domain.Entities.Owner.Report
                {
                    ReportType = ReportType.LocationReport,
                    ReportStateType = ReportStateType.Requested,
                    RequestTime = DateTime.Now
                };
                await _context.Reports.AddAsync(reportRecord,cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await _capPublisher.PublishAsync(ServicesMessageConst.LOCATION_REPORT_REQUESTED, reportRecord.Id,
                    cancellationToken: cancellationToken);
                return reportRecord.Id;
            }
        }
    }
}
