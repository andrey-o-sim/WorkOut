using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.BLL.Interfaces.Services;

namespace WO.Core.BLL.Services
{
    public class ExerciseService : GenericService<ExerciseDTO>, IExerciseService
    {
        IExerciseRepositoryDTO _exerciseRepository;
        public ExerciseService(IExerciseRepositoryDTO repository)
            : base(repository)
        {
            _exerciseRepository = repository;
        }

        public ExerciseDTO GetByName(string name)
        {
            return _exerciseRepository.GetByName(name);
        }
    }
}
