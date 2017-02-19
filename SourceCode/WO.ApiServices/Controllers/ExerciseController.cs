using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers
{
    public class ExerciseController : ApiController
    {
        IService<ExerciseDTO> _exerciseService;
        IMapper _mapper;
        public ExerciseController(IService<ExerciseDTO> exerciseService)
        {
            _exerciseService = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Exercise/5
        public Exercise Get(int id)
        {
            var exerciseDTO = _exerciseService.Get(id);
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            return exercise;
        }

        // GET: api/Exercise
        public IEnumerable<Exercise> GetAll()
        {
            var exercisesDTO = _exerciseService.GetAll();
            var exercises = _mapper.Map<List<Exercise>>(exercisesDTO);
            return exercises;
        }

        // POST: api/Exercise
        [HttpPost]
        public IOperationResult Create([FromBody]Exercise exercise)
        {
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return _exerciseService.Create(exerciseDTO);
        }

        // PUT: api/Exercise/5
        [HttpPut]
        public IOperationResult Update(int id, [FromBody]Exercise exercise)
        {
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            return _exerciseService.Update(exerciseDTO);
        }

        // DELETE: api/Exercise/5
        public IOperationResult Delete(int id)
        {
            return _exerciseService.Delete(id);
        }
    }
}
