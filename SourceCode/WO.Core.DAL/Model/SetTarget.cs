using System.Collections.Generic;

namespace WO.Core.DAL.Model
{
    public class SetTarget : BaseModel
    {
        public int PlainNumberOfTimes { get; set; }
        public string Description { get; set; }

        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }

        public int? SetId { get; set; }
        public virtual Set Set { get; set; }

        public virtual ICollection<ApproachResult> ApproachResults { get; set; } = new List<ApproachResult>();
    }
}
