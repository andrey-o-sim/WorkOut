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
        public DTOTrainingRepository(
            IRepository<Training> repository,
            IRepository<TrainingType> trainingTypeRepository) : base(repository)
        {
            _trainingTypeRepository = trainingTypeRepository;
        }

        public override int Create(TrainingDTO trainingDTO)
        {
            var training = _mapper.Map<Training>(trainingDTO);
            training.CreatedDate = DateTime.Now;
            training.ModifiedDate = DateTime.Now;

            training.TrainingType = _trainingTypeRepository.Get(training.TrainingType.Id);

            return _repository.Create(training);
        }

    }
}
