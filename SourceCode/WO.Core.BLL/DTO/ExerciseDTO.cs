using System.Collections.Generic;

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
