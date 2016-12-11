using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.DAL.Model
{
    public class TrainingType:BaseModel
    {
        [Required]
        public string TypeTraining { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual Training Training { get; set; }
        public int? TrainingId { get; set; }
    }
}
