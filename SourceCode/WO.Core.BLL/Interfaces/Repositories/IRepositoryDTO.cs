using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.Core.BLL.Interfaces.Repositories
{
    public interface IRepositoryDTO<TDto> where TDto : class
    {
        IEnumerable<TDto> GetAll();
        TDto Get(int id);
        int Create(TDto item);
        void Update(TDto item);
        void Delete(int id);
    }
}
