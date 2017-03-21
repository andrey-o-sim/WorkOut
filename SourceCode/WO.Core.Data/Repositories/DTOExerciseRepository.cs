﻿using System;
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
    public class DTOExerciseRepository : DTORepository<Exercise, ExerciseDTO>, IExerciseRepositoryDTO
    {
        public DTOExerciseRepository(IRepository<Exercise> repository) : base(repository)
        { }

        public ExerciseDTO GetByName(string name)
        {
            var exercise = _repository.Find(ex => ex.Name == name);
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);

            return exerciseDTO;
        }
    }
}