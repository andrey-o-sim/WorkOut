using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Model
{
    public class Training : BaseModel
    {
        //кол-во > 0
        public virtual IEnumerable<TrainingType> TrainingTypes { get; set; }
        //кол-во > 0
        public virtual IEnumerable<Set> Sets { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        [Required]
        public string MainTrainingGoal { get; set; }
        public string Description { get; set; }
    }
}
