using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class TrainingTypeDTO : BaseModelDTO
    {
        public string TypeTraining { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<TrainingDTO> Trainings { get; set; }
    }
}
