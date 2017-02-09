using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WO.ApiServices.App_Start;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
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
            _mapper = AutoMapperConfig.MapperConfiguration.CreateMapper();
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
        public void Post([FromBody]TrainingType trainingType)
        {
            var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
            _service.Create(trainingTypeDTO);
        }

        // PUT: api/TrainingType/5
        public void Put(int id, [FromBody]TrainingType trainingType)
        {
            var trainingTypeDTO = _mapper.Map<TrainingTypeDTO>(trainingType);
            _service.Update(trainingTypeDTO);
        }

        // DELETE: api/TrainingType/5
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
