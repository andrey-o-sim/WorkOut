using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.ApiServices.Tests.DTORepositories;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Tests.Services
{
    class TestTrainingTypeService : GenericService<TrainingTypeDTO>
    {
        public TestTrainingTypeService(TestDTORepository<TrainingTypeDTO> repository)
            : base(repository)
        {
        }
    }
}
