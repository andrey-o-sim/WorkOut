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
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers
{
    public class TrainingController : ApiController
    {
        IService<TrainingDTO> _trainingService;
        IMapper _mapper;

        public TrainingController(IService<TrainingDTO> trainingService)
        {
            _trainingService = trainingService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Training/5
        public Training Get(int id)
        {
            var trainigDTO = _trainingService.Get(id);
            var training = _mapper.Map<Training>(trainigDTO);

            return training;
        }

        // GET: api/Training
        public IEnumerable<Training> GetAll()
        {
            var trainigsDTO = _trainingService.GetAll();
            var trainings = _mapper.Map<List<Training>>(trainigsDTO);

            return trainings;
        }

        // POST: api/Training
        [HttpPost]
        public IOperationResult Create([FromBody]Training training)
        {
            var trainigDTO = _mapper.Map<TrainingDTO>(training);
            return _trainingService.Create(trainigDTO);
        }

        // PUT: api/Training/5
        [HttpPut]
        public IOperationResult Update(int id, [FromBody]Training training)
        {
            var trainigDTO = _mapper.Map<TrainingDTO>(training);
            return _trainingService.Update(trainigDTO);
        }

        // DELETE: api/Training/5
        public IOperationResult Delete(int id)
        {
            return _trainingService.Delete(id);
        }
    }
}
