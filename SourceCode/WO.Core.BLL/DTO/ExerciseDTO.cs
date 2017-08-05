using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class ExerciseDTO : BaseModelDTO
    {
        public string Name { get; set; }

        public ICollection<TrainingTypeDTO> TrainingTypes { get; set; }
        public ICollection<SetTargetDTO> SetTargets { get; set; } = new List<SetTargetDTO>();
    }
}
