using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.BLL.DTO
{
    public class ExerciseDTO : BaseModelDTO
    {
        public ExerciseDTO()
        {
            Sets = new List<SetDTO>();
        }

        public string Name { get; set; }

        public ICollection<SetDTO> Sets { get; set; }
    }
}
