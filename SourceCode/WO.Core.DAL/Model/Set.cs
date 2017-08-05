using System;
using System.Collections.Generic;

namespace WO.Core.DAL.Model
{
    public class Set : BaseModel
    {
        public int? PlannedTime { get; set; }
        public int TimeForRest { get; set; }
        public int? SpentTime { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public int? TrainingId { get; set; }
        public virtual Training Training { get; set; }

        public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();

        public  virtual  ICollection<SetTarget> SetTargets { get; set; } = new List<SetTarget>();
    }
}
