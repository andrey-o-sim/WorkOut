using System;
using System.Collections.Generic;
using System.Linq;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTOSetRepository : DTORepository<Set, SetDTO>, IRepositoryDTO<SetDTO>
    {
        private IRepository<Approach> _approachRepository;
        private IRepository<Exercise> _exerciseRepository;
        private IRepository<Training> _trainingRepository;
        private IRepository<SetTarget> _setTargetRepository;

        public DTOSetRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _approachRepository = unitOfWork.GetGenericRepository<Approach>();
            _exerciseRepository = unitOfWork.GetGenericRepository<Exercise>();
            _trainingRepository = unitOfWork.GetGenericRepository<Training>();
            _setTargetRepository = unitOfWork.GetGenericRepository<SetTarget>();
        }

        public override int Create(SetDTO setDto)
        {
            var set = _mapper.Map<Set>(setDto);
            set.CreatedDate = DateTime.Now;
            set.ModifiedDate = DateTime.Now;

            foreach (ApproachDTO approachDto in setDto.Approaches)
            {
                var approach = _approachRepository.Get(approachDto.Id);
                set.Approaches.Add(approach);
            }

            GetTraining(set);
            GetSetTargets(set, setDto);

            _repository.Create(set);
            _unitOfWork.Commit();

            return set.Id;
        }

        public override void Update(SetDTO setDto)
        {
            var setForUpdate = _repository.Get(setDto.Id);
            _mapper.Map<SetDTO, Set>(setDto, setForUpdate);

            setForUpdate.ModifiedDate = DateTime.Now;

            GetTraining(setForUpdate);
            GetSetTargets(setForUpdate, setDto);

            _repository.Update(setForUpdate);
            _unitOfWork.Commit();
        }

        public override void Delete(int id)
        {
            var itemForRemove = _repository.Get(id);
            itemForRemove.Approaches = _approachRepository.FindMany(app => app.SetId == id).ToList();
            itemForRemove.SetTargets = _setTargetRepository.FindMany(setTarget => setTarget.SetId == id).ToList();
            _repository.Delete(itemForRemove);
            _unitOfWork.Commit();
        }

        private void GetTraining(Set setForUpdate)
        {
            if (setForUpdate.TrainingId.HasValue && setForUpdate.TrainingId.Value > 0)
            {
                setForUpdate.Training = _trainingRepository.Get(setForUpdate.TrainingId.Value);
            }
        }

        private void GetSetTargets(Set setForUpdate, SetDTO setDto)
        {
            foreach (var setTarget in setDto.SetTargets)
            {
                var setTargetDb = _setTargetRepository.Get(setTarget.Id);
                setForUpdate.SetTargets.Add(setTargetDb);
            }
        }
    }
}
