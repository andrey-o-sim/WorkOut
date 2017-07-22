using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Model
{
    public class Set : BaseModel
    {
        public int? PlannedTime { get; set; }

        public int TimeForRest { get; set; }

        public int? SpentTime { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

        public virtual ICollection<Approach> Approaches { get; set; } = new List<Approach>();

        public int? TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}
