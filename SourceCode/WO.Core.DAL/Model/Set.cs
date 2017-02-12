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
        [Required]
        public int? TimeForRest { get; set; }
        [Required]
        public int CountApproaches { get; set; }


        //Использовать конвенции
        //кол-во > 0
        [Required]
        public virtual IEnumerable<Exercise> Exercises { get; set; }
        //кол-во > 0
        [Required]
        public virtual IEnumerable<Approach> Approaches { get; set; }
        public int? PlainTime { get; set; }
        public int? SummaryTime { get; set; }
        public int CountMadeApproaches { get; set; }

        public int? TrainingId { get; set; }
        public virtual Training Training { get; set; }//навигационное свойство

        public Set()
        {
            Exercises = new List<Exercise>();
            Approaches = new List<Approach>();
        }
    }
}
