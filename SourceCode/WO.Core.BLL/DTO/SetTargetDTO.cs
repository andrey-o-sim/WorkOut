using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class SetTargetDTO : BaseModelDTO
    {
        public int PlainNumberOfTimes { get; set; }
        public string Description { get; set; }

        public int? ExerciseId { get; set; }
        public ExerciseDTO Exercise { get; set; }

        public int? SetId { get; set; }
        public SetDTO Set { get; set; }

        public ICollection<ApproachResultDTO> ApproachResults { get; set; } = new List<ApproachResultDTO>();
    }
}
