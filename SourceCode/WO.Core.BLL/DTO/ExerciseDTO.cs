using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.BLL.DTO
{
    public class ExerciseDTO : BaseModelDTO
    {
        public string Name { get; set; }

        public SetDTO Set { get; set; }
        public int? SetId { get; set; }
    }
}
