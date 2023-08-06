using Rice.Core.Enums;
using Rice.Core.Extensions;

namespace Rise.Report.Business.Handlers.Report.Models
{
    public class ReportsDto
    {
        public long Id { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime? ProcessTime { get; set; }
        public DateTime? ComplateTime { get; set; }
        public ReportType ReportType { get; set; }

        public string ReportTypetext => ReportType.GetDescription();

        public ReportStateType ReportStateType { get; set; }

        public string ReportStateTypeText => ReportStateType.GetDescription();
         
    }
}
