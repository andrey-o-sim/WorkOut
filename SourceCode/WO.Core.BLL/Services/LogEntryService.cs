using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;

namespace WO.Core.BLL.Services
{
    public class LogEntryService : GenericService<LogEntryDTO>
    {
        public LogEntryService(IRepositoryDTO<LogEntryDTO> repository)
            : base(repository)
        {
        }
    }
}
