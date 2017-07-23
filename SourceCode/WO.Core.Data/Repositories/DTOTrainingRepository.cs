using System;
using System.Collections.Generic;
using System.Linq;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTOTrainingRepository : DTORepository<Training, TrainingDTO>, IRepositoryDTO<TrainingDTO>
    {
        private IRepository<TrainingType> _trainingTypeRepository;
        private IRepository<Set> _setRepository;
        public DTOTrainingRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _trainingTypeRepository = unitOfWork.GetGenericRepository<TrainingType>();
            _setRepository = unitOfWork.GetGenericRepository<Set>();
        }

        public override int Create(TrainingDTO trainingDTO)
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.CreatedDate = DateTime.Now;
            training.ModifiedDate = DateTime.Now;

            training.TrainingType = trainingDTO.TrainingType != null
                ? _trainingTypeRepository.Get(trainingDTO.TrainingType.Id)
                : new TrainingType();

            _repository.Create(training);
            _unitOfWork.Commit();

            UpdateRelatedSets(training.Id, trainingDTO.Sets);

            return training.Id;
        }

        public override void Update(TrainingDTO trainingDTO)
        {
            var trainingForUpdate = _repository.Get(trainingDTO.Id);
            _mapper.Map<TrainingDTO, Training>(trainingDTO, trainingForUpdate);
            trainingForUpdate.ModifiedDate = DateTime.Now;

            if (trainingDTO.TrainingType.Id != trainingForUpdate.TrainingType.Id)
            {
                trainingForUpdate.TrainingType = trainingDTO.TrainingType != null
                    ? _trainingTypeRepository.Get(trainingDTO.TrainingType.Id)
                    : new TrainingType();
                trainingForUpdate.TrainingType.Trainings.Add(trainingForUpdate);
            }

            trainingForUpdate.Sets = _setRepository.FindMany(set => set.TrainingId == trainingDTO.Id).ToList();

            _repository.Update(trainingForUpdate);
            _unitOfWork.Commit();
        }

        private void UpdateRelatedSets(int trainingId, IEnumerable<SetDTO> setDTOs)
        {
            if (trainingId > 0)
            {
                foreach (var setDTO in setDTOs)
                {
                    var set = _setRepository.Get(setDTO.Id);
                    set.TrainingId = trainingId;
                    _setRepository.Update(set);
                }
                _unitOfWork.Commit();
            }
        }
    }
}
