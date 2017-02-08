using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers.GenericData
{
    public class TrainingTypeController : ApiController
    {
        IService<TrainingTypeDTO> _service;
        public TrainingTypeController(IService<TrainingTypeDTO> service)
        {
            _service = service;
        }
        // GET: api/TrainingType
        public IEnumerable<TrainingTypeDTO> Get()
        {
            //var trainingDTO = new List<TrainingTypeDTO>
            //{
            //    new TrainingTypeDTO {Id=1 },
            //    new TrainingTypeDTO {Id=2 }
            //};
            //return trainingDTO;
            //Добавить AutoMapper
            return _service.GetAll();
        }

        // GET: api/TrainingType/5
        public TrainingTypeDTO Get(int id)
        {
            //Добавить AutoMapper
            return _service.Get(id);
        }

        // POST: api/TrainingType
        public void Post([FromBody]TrainingType trainingType)
        {
            //Добавить AutoMapper
            //_service.Create(trainingType);
        }

        // PUT: api/TrainingType/5
        public void Put(int id, [FromBody]TrainingType trainingType)
        {
            //Добавить AutoMapper
            //_service.Update(trainingType);
        }

        // DELETE: api/TrainingType/5
        public void Delete(int id)
        {
            _service.Remove(id);
        }
    }
}
