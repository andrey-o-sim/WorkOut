using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.Core.BLL.Interfaces.Services;

namespace WO.ApiServices.Controllers
{
    [RoutePrefix("api/Exercise")]
    public class ExerciseController : ApiController
    {
        private IExerciseService _service;
        private IMapper _mapper;

        public ExerciseController(IExerciseService exerciseService)
        {
            _service = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Exercise/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var exerciseDTO = _service.Get(id);

            if (exerciseDTO != null)
            {
                var exercise = _mapper.Map<Exercise>(exerciseDTO);
                return Ok<Exercise>(exercise);
            }

            return NotFound();
        }

        [Route("{exerciseName}")]
        public IHttpActionResult GetByName(string exerciseName)
        {
            var exerciseDTO = _service.GetByName(exerciseName);

            if (exerciseDTO != null)
            {
                var exercise = _mapper.Map<Exercise>(exerciseDTO);
                return Ok<Exercise>(exercise);
            }

            return Ok<Exercise>(new Exercise());
        }

        // GET: api/Exercise
        public IHttpActionResult GetAll()
        {
            var exercisesDTO = _service.GetAll();
            var exercises = _mapper.Map<List<Exercise>>(exercisesDTO);

            return Ok<List<Exercise>>(exercises);
        }

        // POST: api/Exercise
        [HttpPost]
        public IHttpActionResult Create([FromBody]Exercise exercise)
        {
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            var result = _service.Create(exerciseDTO);

            return Ok<IOperationResult>(result);
        }

        // PUT: api/Exercise/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Exercise exercise)
        {
            var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
            var result = _service.Update(exerciseDTO);

            return Ok<IOperationResult>(result);
        }

        // DELETE: api/Exercise/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Ok<IOperationResult>(result);
        }
    }
}
