using System.Collections.Generic;

namespace WO.Core.BLL.DTO
{
    public class ExerciseDTO : BaseModelDTO
    {
        public string Name { get; set; }

        public ICollection<SetDTO> Sets { get; set; } = new List<SetDTO>();
    }
}
