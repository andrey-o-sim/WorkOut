using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.DAL.Model
{
    public class Set
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime? TimeForRest { get; set; }
        [Required]
        public int CountApproaches { get; set; }


        //Использовать конвенции
        //кол-во > 0
        [Required]
        public virtual IEnumerable<Exercise> Exercises { get; set; }
        //кол-во > 0
        [Required]
        public virtual IEnumerable<Approach> Approaches { get; set; }
        public DateTime? PlainTime { get; set; }
        public DateTime? SummaryTime { get; set; }
        public int CountMadeApproaches { get; set; }

        public Set()
        {
            Exercises = new List<Exercise>();
            Approaches = new List<Approach>();
        }
    }
}
