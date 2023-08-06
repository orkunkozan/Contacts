using Rice.Core.Context.Entity;

namespace Rise.Report.Domain.Entities.Owner
{
    public class ReportData :IEntity
    {
        public long Id { get; set; } 
        public long ReportId { get; set; } 
        public byte[] Data { get; set; }
        public Report Report { get; set; }
        
    }
}
