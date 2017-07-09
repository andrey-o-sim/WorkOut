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

        public DTOSetRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _approachRepository = unitOfWork.GetGenericRepository<Approach>();
            _exerciseRepository = unitOfWork.GetGenericRepository<Exercise>();
            _trainingRepository = unitOfWork.GetGenericRepository<Training>();
        }

        public override int Create(SetDTO setDto)
        {
            var set = _mapper.Map<Set>(setDto);
            set.CreatedDate = DateTime.Now;
            set.ModifiedDate = DateTime.Now;

            foreach (ExerciseDTO exercisedto in setDto.Exercises)
            {
                var exerciseForUpdate = _exerciseRepository.Get(exercisedto.Id);
                set.Exercises.Add(exerciseForUpdate);
                exerciseForUpdate.Sets.Add(set);
            }

            foreach (ApproachDTO approachDto in setDto.Approaches)
            {
                var approach = _mapper.Map<Approach>(approachDto);
                approach.CreatedDate = DateTime.Now;
                approach.ModifiedDate = DateTime.Now;
                set.Approaches.Add(approach);
            }

            AddDeleteTraining(set);

            _repository.Create(set);
            return _unitOfWork.Commit();
        }

        public override void Update(SetDTO setDto)
        {
            var setForUpdate = _repository.Get(setDto.Id);
            _mapper.Map<SetDTO, Set>(setDto, setForUpdate);

            setForUpdate.ModifiedDate = DateTime.Now;

            AddDeleteExercises(setForUpdate, setDto);
            AddDeleteTraining(setForUpdate);

            _repository.Update(setForUpdate);
            _unitOfWork.Commit();
        }

        public override void Delete(int id)
        {
            var itemForRemove = _repository.Get(id);
            itemForRemove.Approaches = _approachRepository.FindMany(app => app.SetId == id).ToList(); ;
            _repository.Delete(itemForRemove);
            _unitOfWork.Commit();
        }

        private void AddDeleteExercises(Set setForUpdate, SetDTO setDto)
        {
            var setExercises = setForUpdate.Exercises;

            foreach (ExerciseDTO exercisedto in setDto.Exercises)
            {
                if (setExercises.Any(s => s.Id == exercisedto.Id) == false)
                {
                    var exerciseForUpdate = _exerciseRepository.Get(exercisedto.Id);
                    setForUpdate.Exercises.Add(exerciseForUpdate);
                    exerciseForUpdate.Sets.Add(setForUpdate);
                }
            }

            var exercisesForRemove = new List<Exercise>();
            foreach (Exercise exercise in setExercises)
            {
                if (setDto.Exercises.Any(s => s.Id == exercise.Id) == false)
                {
                    exercisesForRemove.Add(exercise);
                }
            }

            foreach (Exercise exerciseForRemove in exercisesForRemove)
            {
                setForUpdate.Exercises.Remove(exerciseForRemove);
                exerciseForRemove.Sets.Remove(setForUpdate);
            }
        }

        private void AddDeleteTraining(Set setForUpdate)
        {
            if (setForUpdate.TrainingId.HasValue && setForUpdate.TrainingId.Value > 0)
            {
                setForUpdate.Training = _trainingRepository.Get(setForUpdate.TrainingId.Value);
            }
            else
            {
                setForUpdate.Training = null;
            }
        }
    }
}
