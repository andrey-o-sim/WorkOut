﻿using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.LoggerFactory;

namespace WO.ApiServices.Controllers.GenericData
{
    public class TrainingTypeController : WoBaseController<TrainingTypeController>
    {
        private IService<TrainingTypeDTO> _service;
        private IMapper _mapper;

        public TrainingTypeController(IService<TrainingTypeDTO> service, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            _service = service;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/TrainingType/5
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Training Type' by id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var trainingTypeDTO = _service.Get(id);
                if (trainingTypeDTO != null)
                {
                    var trainingType = _mapper.Map<TrainingType>(trainingTypeDTO);

                    LogInfoObjectToJson(trainingType);
                    return Ok<TrainingType>(trainingType);
                }

                LoggerService.Info("There is no 'Training Type' with Id = '{0}'", id);

                return NotFound();
            });
        }

        // GET: api/TrainingType
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Training Types'");

            return ExecuteRequest(() =>
            {
                var allTrainingTypesDTO = _service.GetAll();
                var trainingTypes = _mapper.Map<List<TrainingType>>(allTrainingTypesDTO);

                LogInfoObjectToJson(trainingTypes);
                return Ok<List<TrainingType>>(trainingTypes);
            });
        }

        // PUT: api/TrainingType/5
        [HttpPut]
        public IHttpActionResult Save(TrainingType trainingType)
        {
            LogInfoObjectToJson(trainingType, "Saving 'Training Type':");

            return ExecuteRequest(() =>
            {
                var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
                var result = trainingType.Id > 0
                            ? _service.Update(trainingTypeDTO)
                            : _service.Create(trainingTypeDTO);

                LogInfoObjectToJson(trainingType, "Saving 'Training Type':");
                return Ok<IOperationResult>(result);
            });
        }

        // DELETE: api/TrainingType/5
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'Training Type' with id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var result = _service.Delete(id);

                LoggerService.Info("'Training Type' was removed");
                return Ok<IOperationResult>(result);
            });
        }
    }
}
