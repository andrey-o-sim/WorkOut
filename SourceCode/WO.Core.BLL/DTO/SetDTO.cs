using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.BLL.DTO
{
    public class SetDTO : BaseModelDTO
    {
        public DateTime? TimeForRest { get; set; }
        public int CountApproaches { get; set; }
        public DateTime? PlainTime { get; set; }
        public DateTime? SummaryTime { get; set; }
        public int CountMadeApproaches { get; set; }

        public IEnumerable<ExerciseDTO> Exercises { get; set; }
        public IEnumerable<ApproachDTO> Approaches { get; set; }
        public SetDTO()
        {
            Exercises = new List<ExerciseDTO>();
            Approaches = new List<ApproachDTO>();
        }
    }
}
