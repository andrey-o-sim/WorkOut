using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Services;

namespace WO.Core.BLL.Interfaces.Services
{
    public interface IApproachService : IService<ApproachDTO>
    {
        ICollection<ApproachDTO> GenerateApproachesForSet(SetDTO setDTO);
    }
}
