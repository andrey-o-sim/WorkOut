using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTOSetRepository : DTORepository<Set, SetDTO>, IRepositoryDTO<SetDTO>
    {
        public DTOSetRepository(IRepository<Set> setRepository)
            : base(setRepository)
        { }

        public override int Create(SetDTO setDto)
        {
            var set = _mapper.Map<Set>(setDto);
            set.CreatedDate = DateTime.Now;
            set.ModifiedDate = DateTime.Now;

            foreach (Exercise exercise in set.Exercises)
            {
                _repository.AttachToContext<Exercise>(exercise);
            }

            foreach(Approach approach in set.Approaches)
            {
                approach.CreatedDate = DateTime.Now;
                approach.ModifiedDate = DateTime.Now;
            }

            return _repository.Create(set);
        }

        public override void Update(SetDTO setDto)
        {
            var set = _mapper.Map<Set>(setDto);
            set.ModifiedDate = DateTime.Now;

            foreach (Exercise exercise in set.Exercises)
            {
                _repository.AttachToContext<Exercise>(exercise);
            }

            foreach (Approach approach in set.Approaches)
            {
                _repository.AttachToContext<Approach>(approach);
            }

            _repository.Update(set);
        }
    }
}
