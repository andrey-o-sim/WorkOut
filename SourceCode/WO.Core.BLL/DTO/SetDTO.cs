using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class SetDTO : BaseModelDTO
    {
        public int? PlannedTime { get; set; }
        public int TimeForRest { get; set; }
        public int? SpentTime { get; set; }
        public int CountApproaches { get; set; }

        public ICollection<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();
        public ICollection<ApproachDTO> Approaches { get; set; } = new List<ApproachDTO>();
        public TrainingDTO Training { get; set; }
        public int? TrainingId { get; set; }
    }
}
