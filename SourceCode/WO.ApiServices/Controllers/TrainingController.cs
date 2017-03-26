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

namespace WO.ApiServices.Controllers
{
    public class TrainingController : ApiController
    {
        private IService<TrainingDTO> _service;
        private IMapper _mapper;

        public TrainingController(IService<TrainingDTO> trainingService)
        {
            _service = trainingService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Training/5
        public IHttpActionResult Get(int id)
        {
            var trainigDTO = _service.Get(id);
            if (trainigDTO != null)
            {
                var training = _mapper.Map<Training>(trainigDTO);
                return Ok<Training>(training);
            }

            return NotFound();
        }

        // GET: api/Training
        public IHttpActionResult GetAll()
        {
            var trainigsDTO = _service.GetAll();
            var trainings = _mapper.Map<List<Training>>(trainigsDTO);

            return Ok<List<Training>>(trainings);
        }

        // POST: api/Training
        [HttpPost]
        public IHttpActionResult Create([FromBody]Training training)
        {
            var trainigDTO = _mapper.Map<TrainingDTO>(training);
            var result = _service.Create(trainigDTO);

            return Ok<IOperationResult>(result);
        }

        // PUT: api/Training/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Training training)
        {
            var trainigDTO = _mapper.Map<TrainingDTO>(training);
            var result = _service.Update(trainigDTO);

            return Ok<IOperationResult>(result);
        }

        // DELETE: api/Training/5
        public IHttpActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Ok<IOperationResult>(result);
        }
    }
}
