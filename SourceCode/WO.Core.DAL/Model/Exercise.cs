using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.DAL.Model
{
    public class Exercise : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<TrainingType> TrainingTypes { get; set; } = new List<TrainingType>();
        public virtual ICollection<SetTarget> SetTargets { get; set; } = new List<SetTarget>();
    }
}
