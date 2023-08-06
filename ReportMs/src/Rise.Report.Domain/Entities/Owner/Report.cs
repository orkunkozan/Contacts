using Rice.Core.Context.Entity;
using Rice.Core.Enums;

namespace Rise.Report.Domain.Entities.Owner
{
    public class Report : IEntity
    {
        public long Id { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime? ProcessTime { get; set; }
        public DateTime? ComplateTime { get; set; }
        public ReportType ReportType { get; set; }
        public ReportStateType ReportStateType { get; set; } 

        public ReportData? ReportData { get; set; }
    }
}
