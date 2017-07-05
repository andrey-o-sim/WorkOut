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

            try
            {
                var exerciseDTO = _service.Get(id);

                if (exerciseDTO != null)
                {
                    var exercise = _mapper.Map<Exercise>(exerciseDTO);

                    LogInfoObjectToJson(exercise);
                    return Ok<Exercise>(exercise);
                }
                else
                {
                    LoggerService.Info("There is no 'Exercise' with Id = '{0}'", id);
                }
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during getting 'Exercise' with id = {0}", id);
            }

            return NotFound();
        }

        [Route("{exerciseName}")]
        public IHttpActionResult GetByName(string exerciseName)
        {
            LoggerService.Info("Getting 'Exercise' by Name = '{0}'", exerciseName);

            try
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
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during getting 'Exercise' with id = {0}", exerciseName);
            }

            return NotFound();
        }

        // GET: api/Exercise
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Exercises'");

            try
            {
                var exercisesDTO = _service.GetAll();
                var exercises = _mapper.Map<List<Exercise>>(exercisesDTO);

                LogInfoObjectToJson(exercises);
                return Ok<List<Exercise>>(exercises);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during getting all 'Exercises'");
            }

            return NotFound();
        }

        // POST: api/Exercise
        [HttpPost]
        public IHttpActionResult Create([FromBody]Exercise exercise)
        {
            LogInfoObjectToJson(exercise, "Creating 'Exercise':");

            try
            {
                var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
                var result = _service.Create(exerciseDTO);

                LogInfoObjectToJson(result, "Created 'Exercise':");
                return Ok<IOperationResult>(result);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during creating 'Exercise'");
            }

            return Ok<IOperationResult>(DefaultOperatingResult);
        }

        // PUT: api/Exercise/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Exercise exercise)
        {
            LogInfoObjectToJson(exercise, "Updating 'Exercise':");

            try
            {
                var exerciseDTO = _mapper.Map<ExerciseDTO>(exercise);
                var result = _service.Update(exerciseDTO);

                LogInfoObjectToJson(result, "Updated 'Exercise':");
                return Ok<IOperationResult>(result);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during updating 'Exercise'");
            }

            return Ok<IOperationResult>(DefaultOperatingResult);
        }

        // DELETE: api/Exercise/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'Exercise' with id = '{0}'", id);

            try
            {
                var result = _service.Delete(id);

                LoggerService.Info("'Exercise' was removed");
                return Ok<IOperationResult>(result);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during deleting 'Exercise'");
            }

            return Ok<IOperationResult>(DefaultOperatingResult);
        }
    }
}
