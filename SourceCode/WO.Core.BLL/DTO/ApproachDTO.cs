using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class ApproachDTO : BaseModelDTO
    {
        public int PlannedTimeForRest { get; set; }
        public int SpentTimeForRest { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public SetDTO Set { get; set; }
        public int? SetId { get; set; }

        public ICollection<ApproachResultDTO> ApproachResults { get; set; } = new List<ApproachResultDTO>();
    }
}
