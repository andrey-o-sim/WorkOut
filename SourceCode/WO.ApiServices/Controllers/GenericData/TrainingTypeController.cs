using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers.GenericData
{
    public class TrainingTypeController : ApiController
    {
        IService<TrainingTypeDTO> _service;
        IMapper _mapper;
        public TrainingTypeController(IService<TrainingTypeDTO> service)
        {
            _service = service;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }
        // GET: api/TrainingType
        public IEnumerable<TrainingType> Get()
        {
            var allTrainingTypes = _service.GetAll();
            return _mapper.Map<List<TrainingType>>(allTrainingTypes);
        }

        // GET: api/TrainingType/5
        public TrainingType Get(int id)
        {
            var trainingType = _service.Get(id);
            return _mapper.Map<TrainingType>(trainingType);
        }

        // POST: api/TrainingType
        [HttpPost]
        public IOperationResult Create([FromBody]TrainingType trainingType)
        {
            var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
            return _service.Create(trainingTypeDTO);
        }

        // PUT: api/TrainingType/5
        [HttpPut]
        public IOperationResult Update(int id, [FromBody]TrainingType trainingType)
        {
            var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
            return _service.Update(trainingTypeDTO);
        }

        // DELETE: api/TrainingType/5
        public IOperationResult Delete(int id)
        {
            return _service.Remove(id);
        }
    }
}
