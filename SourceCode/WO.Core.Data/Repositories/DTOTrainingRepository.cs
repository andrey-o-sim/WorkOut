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
            IRepository<Training> repository,
            IRepository<TrainingType> trainingTypeRepository,
            IRepository<Set> setRepository) : base(repository)
        {
            _trainingTypeRepository = trainingTypeRepository;
            _setRepository = setRepository;
        }

        public override int Create(TrainingDTO trainingDTO)
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.CreatedDate = DateTime.Now;
            training.ModifiedDate = DateTime.Now;

            training.TrainingType = _trainingTypeRepository.Get(training.TrainingType.Id);

            return _repository.Create(training);
        }

        public override void Update(TrainingDTO trainingDTO)
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.ModifiedDate = DateTime.Now;

            training.TrainingType = trainingDTO.TrainingType != null 
                ? _trainingTypeRepository.Get(trainingDTO.TrainingType.Id) 
                : new TrainingType();
            training.Sets = _setRepository.FindMany(set => set.TrainingId == trainingDTO.Id).ToList();

            _repository.Update(training);
        }

    }
}
