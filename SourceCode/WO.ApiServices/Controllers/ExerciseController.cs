using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.Core.BLL.Interfaces.Services;
using WO.LoggerFactory;
using System;

namespace WO.ApiServices.Controllers
{
    [RoutePrefix("api/Exercise")]
    public class ExerciseController : WoBaseController<ExerciseController>
    {
        private IExerciseService _service;
        private IMapper _mapper;

        public ExerciseController(IExerciseService exerciseService, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            _service = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Exercise/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Exercise' by id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var exerciseDTO = _service.Get(id);

                if (exerciseDTO != null)
                {
                    var exercise = _mapper.Map<Exercise>(exerciseDTO);

                    LogInfoObjectToJson(exercise);
                    return Ok<Exercise>(exercise);
                }

                LoggerService.Info("There is no 'Exercise' with Id = '{0}'", id);

                return NotFound();
            });
        }

        [Route("{exerciseName}")]
        public IHttpActionResult GetByName(string exerciseName)
        {
            LoggerService.Info("Getting 'Exercise' by Name = '{0}'", exerciseName);

            return ExecuteRequest(() =>
            {
                var exerciseDTO = _service.GetByName(exerciseName);

                if (exerciseDTO != null)
                {
                    var exercise = _mapper.Map<Exercise>(exerciseDTO);

                    LogInfoObjectToJson(exercise);
                    return Ok<Exercise>(exercise);
                }
                else
                {
                    LoggerService.Info("There is no 'Exercise' with Name = '{0}'", exerciseName);
                }

                return Ok<Exercise>(new Exercise());
            });
        }

        // GET: api/Exercise
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Exercises'");

            return ExecuteRequest(() =>
            {
                var exercisesDTO = _service.GetAll();
                var exercises = _mapper.Map<List<Exercise>>(exercisesDTO);

                LogInfoObjectToJson(exercises);
                return Ok<List<Exercise>>(exercises);
            });
        }

        // PUT: api/Exercise/5
        [HttpPut]
        public IHttpActionResult Save([FromBody]Exercise exercise)
        {
            LogInfoObjectToJson(exercise, "Saving 'Exercise':");

            return ExecuteRequest(() =>
            {
                var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
                var result = exercise.Id > 0
                            ? _service.Update(exerciseDTO)
                            :_service.Create(exerciseDTO);

                LogInfoObjectToJson(result, "Saving 'Exercise':");
                return Ok<IOperationResult>(result);
            });
        }

        // DELETE: api/Exercise/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'Exercise' with id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var result = _service.Delete(id);

                LoggerService.Info("'Exercise' was removed");
                return Ok<IOperationResult>(result);
            });
        }
    }
}
