using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Interfaces.Repositories;

namespace WO.Core.BLL.Services.GenericDataServices
{
    public class TrainingTypeService : GenericService<TrainingTypeDTO>
    {
        public TrainingTypeService(IRepositoryDTO<TrainingTypeDTO> repository)
            : base(repository)
        {
        }
    }
}
