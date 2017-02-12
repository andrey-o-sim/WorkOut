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
        // GET: api/Exercise
        public IEnumerable<Exercise> Get()
        {
            var exercisesDTO = _exerciseService.GetAll();
            var exercises = _mapper.Map<List<Exercise>>(exercisesDTO);
            return exercises;
        }

        // GET: api/Exercise/5
        public Exercise Get(int id)
        {
            var exerciseDTO = _exerciseService.Get(id);
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            return exercise;
        }

        // POST: api/Exercise
        [HttpPost]
        public void Create([FromBody]Exercise exercise)
        {
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            _exerciseService.Create(exerciseDTO);
        }

        // PUT: api/Exercise/5
        [HttpPut]
        public void Update(int id, [FromBody]Exercise exercise)
        {
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            _exerciseService.Update(exerciseDTO);
        }

        // DELETE: api/Exercise/5
        public void Delete(int id)
        {
            _exerciseService.Remove(id);
        }
    }
}
