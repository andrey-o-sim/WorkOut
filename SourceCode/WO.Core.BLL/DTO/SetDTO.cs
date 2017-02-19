using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class SetDTO : BaseModelDTO
    {
        public SetDTO()
        {
            Exercises = new List<ExerciseDTO>();
            Approaches = new List<ApproachDTO>();
        }

        public int? TimeForRest { get; set; }
        public int CountApproaches { get; set; }
        public int? PlainTime { get; set; }
        public int? SummaryTime { get; set; }
        public int CountMadeApproaches { get; set; }

        public IEnumerable<ExerciseDTO> Exercises { get; set; }
        public IEnumerable<ApproachDTO> Approaches { get; set; }
        public TrainingDTO Training { get; set; }
    }
}
