using System;
using System.Collections.Generic;
using System.Linq;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces.Repositories;
using WO.Core.DAL.Interfaces;
using WO.Core.DAL.Model;

namespace WO.Core.Data.Repositories
{
    public class DTOExerciseRepository : DTORepository<Exercise, ExerciseDTO>, IExerciseRepositoryDTO
    {
        IRepository<TrainingType> _trainingTypeRepository;
        public DTOExerciseRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _trainingTypeRepository = unitOfWork.GetGenericRepository<TrainingType>();
        }

        public ExerciseDTO GetByName(string name)
        {
            var exercise = _repository.Find(ex => ex.Name == name);

            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);

            return exerciseDTO;
        }

        public override int Create(ExerciseDTO item)
        {
            var exerciseItem = _mapper.Map<Exercise>(item);

            foreach (var trainingType in item.TrainingTypes)
            {
                var contextTrainingType = _trainingTypeRepository.Get(trainingType.Id);
                exerciseItem.TrainingTypes.Add(contextTrainingType);
                contextTrainingType.Exercises.Add(exerciseItem);
            }

            exerciseItem.CreatedDate = DateTime.Now;
            exerciseItem.ModifiedDate = DateTime.Now;

            _repository.Create(exerciseItem);
            _unitOfWork.Commit();

            return exerciseItem.Id;
        }

        public override void Update(ExerciseDTO exerciseDto)
        {
            var exerciseForUpdate = _repository.Get(exerciseDto.Id);
            _mapper.Map<ExerciseDTO, Exercise>(exerciseDto, exerciseForUpdate);

            AddDeleteTrainingTypes(exerciseForUpdate, exerciseDto);

            exerciseForUpdate.ModifiedDate = DateTime.Now;

            _repository.Update(exerciseForUpdate);
            _unitOfWork.Commit();
        }

        private void AddDeleteTrainingTypes(Exercise exerciseForUpdate, ExerciseDTO exerciseDto)
        {
            var exerciseTrainingTypes = exerciseForUpdate.TrainingTypes;

            foreach (TrainingTypeDTO trainingTypeDto in exerciseDto.TrainingTypes)
            {
                if (exerciseTrainingTypes.Any(tt => tt.Id == trainingTypeDto.Id) == false)
                {
                    var trainingTypeForUpdate = _trainingTypeRepository.Get(trainingTypeDto.Id);

                    trainingTypeForUpdate.Exercises.Add(exerciseForUpdate);
                    exerciseForUpdate.TrainingTypes.Add(trainingTypeForUpdate);
                }
            }

            var trainingTypesForRemove = new List<TrainingType>();
            foreach (TrainingType trainingType in exerciseTrainingTypes)
            {
                if (exerciseDto.TrainingTypes.Any(tt => tt.Id == trainingType.Id) == false)
                {
                    trainingTypesForRemove.Add(trainingType);
                }
            }

            foreach (TrainingType trainingTypeForRemove in trainingTypesForRemove)
            {
                exerciseForUpdate.TrainingTypes.Remove(trainingTypeForRemove);
                trainingTypeForRemove.Exercises.Remove(exerciseForUpdate);
            }
        }

    }
}
