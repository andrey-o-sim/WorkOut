﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        IRepository<Approach> _approachRepository;
        IRepository<Exercise> _exerciseRepository;

        public DTOSetRepository(IRepository<Set> setRepository,
            IRepository<Approach> approachRepository,
            IRepository<Exercise> exerciseRepository)
            : base(setRepository)
        {
            _approachRepository = approachRepository;
            _exerciseRepository = exerciseRepository;
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

            return _repository.Create(set);
        }

        public override void Update(SetDTO setDto)
        {
            var setForUpdate = _repository.Get(setDto.Id);
            _mapper.Map<SetDTO, Set>(setDto, setForUpdate);

            setForUpdate.ModifiedDate = DateTime.Now;

            AddDeleteExercises(setForUpdate, setDto);

            //After add new approach button need to check and remove the method
            AddApproaches(setForUpdate, setDto);

            _repository.Update(setForUpdate);
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

            foreach(Exercise exerciseForRemove in exercisesForRemove)
            {
                setForUpdate.Exercises.Remove(exerciseForRemove);
                exerciseForRemove.Sets.Remove(setForUpdate);
            }
        }

        private void AddApproaches(Set setForUpdate, SetDTO setDto)
        {
            var setApporoaches = setForUpdate.Approaches;

            foreach (ApproachDTO approachDto in setDto.Approaches)
            {
                if (setApporoaches.Any(s => s.Id == approachDto.Id) == false)
                {
                    var approachForUpdate = _approachRepository.Get(approachDto.Id);
                    setForUpdate.Approaches.Add(approachForUpdate);
                }
            }
        }
    }
}
