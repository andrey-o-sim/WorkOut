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
        public Set()
        {
            Exercises = new List<Exercise>();
            Approaches = new List<Approach>();
        }

        public int? PlannedTime { get; set; }

        [Required]
        public int TimeForRest { get; set; }

        public int? SpentTime { get; set; }

        [Required]
        public virtual ICollection<Exercise> Exercises { get; set; }

        [Required]
        public virtual ICollection<Approach> Approaches { get; set; }

        public int? TrainingId { get; set; }
        public virtual Training Training { get; set; }
    }
}
