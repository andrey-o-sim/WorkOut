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

        public int? PlannedTime { get; set; }
        public int TimeForRest { get; set; }
        public int CountApproaches { get; set; }
        public int? SpentTime { get; set; }
        public int? CountMadeApproaches { get; set; }

        public ICollection<ExerciseDTO> Exercises { get; set; }
        public ICollection<ApproachDTO> Approaches { get; set; }
        public TrainingDTO Training { get; set; }
    }
}
