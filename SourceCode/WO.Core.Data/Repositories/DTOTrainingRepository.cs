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
    public class DTOTrainingRepository : DTORepository<Training, TrainingDTO>, IRepositoryDTO<TrainingDTO>
    {
        private IRepository<TrainingType> _trainingTypeRepository;
        private IRepository<Set> _setRepository;
        public DTOTrainingRepository(
            IUnitOfWork unitOfWork,
            IRepository<TrainingType> trainingTypeRepository,
            IRepository<Set> setRepository) : base(unitOfWork)
        {
            _trainingTypeRepository = trainingTypeRepository;
            _setRepository = setRepository;
        }

        public override int Create(TrainingDTO trainingDTO)
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.CreatedDate = DateTime.Now;
            training.ModifiedDate = DateTime.Now;

            training.TrainingType = trainingDTO.TrainingType != null
                ? _trainingTypeRepository.Get(trainingDTO.TrainingType.Id)
                : new TrainingType();

            return _repository.Create(training);
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
        }

    }
}
