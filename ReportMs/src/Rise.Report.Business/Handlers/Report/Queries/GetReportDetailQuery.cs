using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rice.Core.Enums;
using Rise.Report.Business.Handlers.Report.Models;
using Rise.Report.Infrastructure.DataAccess.Contexts; 

namespace Rise.Report.Business.Handlers.Report.Queries
{
    public class GetReportDetailQuery : IRequest<object?>
    {   
        public  long ReportId { get; set; }
        public class GetReportDetailQueryHandler : IRequestHandler<GetReportDetailQuery, object?>
        {
            private readonly ReportContext _context;
            public GetReportDetailQueryHandler(ReportContext context)
            {
                _context = context;
            }

            public async Task<object?> Handle(GetReportDetailQuery request, CancellationToken cancellationToken)
            {
                var reportDataRecord = await _context.ReportDatas.Include(i=>i.Report).Where(w => w.ReportId == request.ReportId)
                    .FirstOrDefaultAsync(cancellationToken); 

                var jsonData =  System.Text.Encoding.UTF8.GetString(reportDataRecord.Data);

                switch (reportDataRecord.Report.ReportType)
                {
                    case ReportType.LocationReport:
                   return JsonSerializer.Deserialize<List<LocationReportDto>>(jsonData);
                    default:
                        return null;
                } 
            }
        }
    }
}
