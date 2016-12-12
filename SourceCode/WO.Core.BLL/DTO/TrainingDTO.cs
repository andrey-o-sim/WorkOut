using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.BLL.DTO
{
    public class TrainingDTO : BaseModelDTO
    {
        public IEnumerable<TrainingTypeDTO> TrainingTypes { get; set; }
        public IEnumerable<SetDTO> Sets { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string MainTrainingPurpose { get; set; }
        public string Description { get; set; }
    }
}
