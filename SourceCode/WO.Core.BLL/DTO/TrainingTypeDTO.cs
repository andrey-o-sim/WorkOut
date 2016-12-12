using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.BLL.DTO
{
    public class TrainingTypeDTO : BaseModelDTO
    {
        public string TypeTraining { get; set; }
        public string Description { get; set; }

        public TrainingDTO Training { get; set; }
        public int? TrainingId { get; set; }
    }
}
