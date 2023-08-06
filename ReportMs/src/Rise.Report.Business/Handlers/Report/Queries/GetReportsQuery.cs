using MediatR;
using Microsoft.EntityFrameworkCore; 
using Rise.Report.Business.Handlers.Report.Models;
using Rise.Report.Infrastructure.DataAccess.Contexts;

namespace Rise.Report.Business.Handlers.Report.Queries
{
    public class GetReportsQuery : IRequest<List<ReportsDto>>
    {   
        public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<ReportsDto>>
        {
            private readonly ReportContext _context;
            public GetReportsQueryHandler(ReportContext context)
            {
                _context = context;
            }

            public async Task<List<ReportsDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.Reports
                    .Select(s => new ReportsDto
                    { 
                        Id = s.Id, 
                        ReportType = s.ReportType,
                        ComplateTime = s.ComplateTime,
                        ProcessTime = s.ProcessTime,
                        ReportStateType = s.ReportStateType,
                        RequestTime = s.RequestTime
                    }).ToListAsync(cancellationToken);
                return result;
            }
        }
    }
}
