using Microsoft.EntityFrameworkCore;

namespace Rice.Core.Context.Model
{
    public class ChangeTrackState
    {
        public int Index { get; set; }
        public EntityState State { get; set; }
    }
}
