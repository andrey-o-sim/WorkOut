using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.LoggerService;
using WO.LoggerFactory;

namespace WO.ApiServices.Controllers.GenericData
{
    public class TrainingTypeController : ApiController
    {
        private IService<TrainingTypeDTO> _service;
        private IMapper _mapper;
        private ILoggerService _loggerService;

        public TrainingTypeController(IService<TrainingTypeDTO> service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
            _loggerService = loggerFactory.Create<TrainingController>();
        }

        // GET: api/TrainingType/5
        public IHttpActionResult Get(int id)
        {
            var trainingTypeDTO = _service.Get(id);
            if (trainingTypeDTO != null)
            {
                var trainingType = _mapper.Map<TrainingType>(trainingTypeDTO);
                return Ok<TrainingType>(trainingType);
            }

            return NotFound();
        }

        // GET: api/TrainingType
        public IHttpActionResult GetAll()
        {
            var allTrainingTypesDTO = _service.GetAll();
            var trainingTypes = _mapper.Map<List<TrainingType>>(allTrainingTypesDTO);

            return Ok<List<TrainingType>>(trainingTypes);
        }

        // POST: api/TrainingType
        [HttpPost]
        public IHttpActionResult Create(TrainingType trainingType)
        {
            var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
            var result = _service.Create(trainingTypeDTO);

            return Ok<IOperationResult>(result);
        }

        // PUT: api/TrainingType/5
        [HttpPut]
        public IHttpActionResult Update(TrainingType trainingType)
        {
            var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
            var result = _service.Update(trainingTypeDTO);

            return Ok<IOperationResult>(result);
        }

        // DELETE: api/TrainingType/5
        public IHttpActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Ok<IOperationResult>(result);
        }
    }
}
