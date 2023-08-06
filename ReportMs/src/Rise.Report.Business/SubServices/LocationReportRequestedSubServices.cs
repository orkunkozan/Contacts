using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Rice.Core.Const;
using Rice.Core.CustomExceptions;
using Rice.Core.Enums;
using Rice.Core.SubServices;
using Rise.Report.Business.Handlers.Report.Models;
using Rise.Report.Domain.Entities.Owner;
using Rise.Report.Infrastructure.DataAccess.Contexts;

namespace Rise.Report.Business.SubServices
{
    public class LocationReportRequestedSubServices : BaseSubServices<ReportSubscribeDbContext>
    {

        public LocationReportRequestedSubServices(ReportSubscribeDbContext context) : base(context)
        {

        }

        [CapSubscribe(ServicesMessageConst.LOCATION_REPORT_REQUESTED)]
        public async Task Do(long reportId)
        {
            var reportRecort = await _context.Reports.Where(w => w.Id == reportId).FirstOrDefaultAsync(CancellationToken.None);

            if (reportRecort == null)
            {
                throw new ProjectException("Oluşturulmak istenen rapor sistemde mevcut değil !");
            }
            reportRecort.ProcessTime = DateTime.Now;
            reportRecort.ReportStateType = ReportStateType.Processing;

            await _context.SaveChangesAsync(CancellationToken.None);

            var sql = from x in _context.Contacts
                      join y in _context.Persons on x.PersonId equals y.Id
                      where x.ContactType == ContactType.Location
                      group x by x.Content
                into grp
                      select new LocationReportDto
                      {
                          Location = grp.Key,
                          Count = grp.Select(s => s.PersonId).Distinct().Count()
                      };

            var list = sql.ToList();

            var jsonText = JsonSerializer.Serialize(list);

            var byteData = System.Text.Encoding.UTF8.GetBytes(jsonText);

            var reportDataRecord = (await _context.ReportDatas.FirstOrDefaultAsync(w => w.ReportId == reportId, CancellationToken.None)) ??
                new ReportData();

            reportDataRecord.ReportId = reportId;
            reportDataRecord.Data = byteData;

            if (reportDataRecord.Id == 0)
            {
                await _context.ReportDatas.AddAsync(reportDataRecord, CancellationToken.None);
            }

            reportRecort.ReportStateType = ReportStateType.Completed;
            reportRecort.ComplateTime = DateTime.Now;

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
