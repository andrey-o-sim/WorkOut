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
    public class DTOSetTargetRepository : DTORepository<SetTarget, SetTargetDTO>, IRepositoryDTO<SetTargetDTO>
    {
        private IRepository<Exercise> _exerciseRepository;
        private IRepository<Set> _setRepository;

        public DTOSetTargetRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _exerciseRepository = unitOfWork.GetGenericRepository<Exercise>();
            _setRepository = unitOfWork.GetGenericRepository<Set>();
        }

        public override int Create(SetTargetDTO setTargetDTO)
        {
            var setTarget = _mapper.Map<SetTarget>(setTargetDTO);
            setTarget.CreatedDate = DateTime.Now;
            setTarget.ModifiedDate = DateTime.Now;

            SetSubItems(setTarget, setTargetDTO);

            _repository.Create(setTarget);
            _unitOfWork.Commit();

            return setTarget.Id;
        }

        public override void Update(SetTargetDTO setTargetDTO)
        {
            var setTargetForUpdate = _repository.Get(setTargetDTO.Id);
            _mapper.Map<SetTargetDTO, SetTarget>(setTargetDTO, setTargetForUpdate);
            setTargetForUpdate.ModifiedDate = DateTime.Now;

            SetSubItems(setTargetForUpdate,setTargetDTO);

            _repository.Update(setTargetForUpdate);
            _unitOfWork.Commit();
        }

        private void SetSubItems(SetTarget setTarget, SetTargetDTO setTargetDTO)
        {
            var exerciseId = setTargetDTO.Exercise != null
                ? setTargetDTO.Exercise.Id
                : setTargetDTO.ExerciseId;

            setTarget.Exercise = exerciseId.HasValue
                ? _exerciseRepository.Get(exerciseId.Value)
                : null;

            var setId = setTargetDTO.Set != null
                ? setTargetDTO.Set.Id
                : setTargetDTO.SetId;

            setTarget.Set = setId.HasValue
                ? _setRepository.Get(setId.Value)
                : null;
        }
    }
}
