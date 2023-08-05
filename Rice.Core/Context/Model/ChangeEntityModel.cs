using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rice.Core.Context.Model
{
    public class ChangeEntityModel
    {
        public List<ChangeTrackState> ChangeTrackStates { get; set; }
        public EntityEntry[] ChangeTrack { get; set; }
    }
}
