using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.LoggerFactory;

namespace WO.ApiServices.Controllers
{
    public class TrainingController : WoBaseController<TrainingController>
    {
        private IService<TrainingDTO> _service;
        private IMapper _mapper;

        public TrainingController(IService<TrainingDTO> trainingService, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            _service = trainingService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Training/5
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Training' by id = '{0}'", id);

            try
            {
                var trainigDTO = _service.Get(id);
                if (trainigDTO != null)
                {
                    var training = _mapper.Map<Training>(trainigDTO);

                    LogInfoObjectToJson(training);
                    return Ok<Training>(training);
                }
                else
                {
                    LoggerService.Info("There is no 'Training' with Id = '{0}'", id);
                }
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during getting 'Training' with id = {0}", id);
            }

            return NotFound();
        }

        // GET: api/Training
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Trainings'");

            try
            {
                var trainigsDTO = _service.GetAll();
                var trainings = _mapper.Map<List<Training>>(trainigsDTO);

                LogInfoObjectToJson(trainings);
                return Ok<List<Training>>(trainings);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during getting all 'Trainings'");
            }

            return NotFound();
        }

        // POST: api/Training
        [HttpPost]
        public IHttpActionResult Create([FromBody]Training training)
        {
            LogInfoObjectToJson(training, "Creating 'Training':");

            try
            {
                var trainigDTO = _mapper.Map<TrainingDTO>(training);
                var result = _service.Create(trainigDTO);

                LogInfoObjectToJson(result, "Created 'Training':");
                return Ok<IOperationResult>(result);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during creating 'Training'");
            }

            return Ok<IOperationResult>(DefaultOperatingResult);
        }

        // PUT: api/Training/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Training training)
        {
            LogInfoObjectToJson(training, "Updating 'Training':");

            try
            {
                var trainigDTO = _mapper.Map<TrainingDTO>(training);
                var result = _service.Update(trainigDTO);

                LogInfoObjectToJson(result, "Updated 'Training':");
                return Ok<IOperationResult>(result);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during updating 'Training'");
            }

            return Ok<IOperationResult>(DefaultOperatingResult);
        }

        // DELETE: api/Training/5
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'Training' with id = '{0}'", id);

            try
            {
                var result = _service.Delete(id);

                LoggerService.Info("'Training' was removed");
                return Ok<IOperationResult>(result);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Error during deleting 'Training'");
            }

            return Ok<IOperationResult>(DefaultOperatingResult);
        }
    }
}
