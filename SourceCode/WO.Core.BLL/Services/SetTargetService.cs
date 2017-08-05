using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;

namespace WO.Core.BLL.Services
{
    public class SetTargetService : GenericService<SetTargetDTO>
    {
        IRepositoryDTO<SetTargetDTO> _setTargetRepository;
        public SetTargetService(IRepositoryDTO<SetTargetDTO> repository) 
            : base(repository)
        {
            _setTargetRepository = repository;
        }
    }
}
