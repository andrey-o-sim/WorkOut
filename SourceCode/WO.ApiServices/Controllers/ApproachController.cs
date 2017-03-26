using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers
{
    public class ApproachController : ApiController
    {
        private IService<ApproachDTO> _service;
        private IMapper _mapper;

        public ApproachController(IService<ApproachDTO> approachService)
        {
            _service = approachService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Approach/5
        public IHttpActionResult Get(int id)
        {
            var approachDTO = _service.Get(id);
            if (approachDTO != null)
            {
                var approach = _mapper.Map<Approach>(approachDTO);
                return Ok<Approach>(approach);
            }

            return NotFound();
        }

        // GET: api/Approach
        public IHttpActionResult GetAll()
        {
            var approachesDTO = _service.GetAll();
            var approaches = _mapper.Map<List<Approach>>(approachesDTO);

            return Ok<List<Approach>>(approaches);
        }

        // POST: api/Approach
        [HttpPost]
        public IHttpActionResult Create([FromBody]Approach approach)
        {
            var approachDTO = _mapper.Map<ApproachDTO>(approach);
            var result = _service.Create(approachDTO);

            return Ok<IOperationResult>(result);
        }

        // PUT: api/Approach/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Approach approach)
        {
            var approachDTO = _mapper.Map<ApproachDTO>(approach);
            var result = _service.Update(approachDTO);

            return Ok<IOperationResult>(result);
        }

        // DELETE: api/Approach/5
        public IHttpActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Ok<IOperationResult>(result);
        }
    }
}
