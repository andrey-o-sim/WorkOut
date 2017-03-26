using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;

namespace WO.Core.BLL.Interfaces.Repositories
{
    public interface IExerciseRepositoryDTO : IRepositoryDTO<ExerciseDTO>
    {
        ExerciseDTO GetByName(string name);
    }
}
