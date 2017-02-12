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
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers
{
    public class ApproachController : ApiController
    {
        IService<ApproachDTO> _approachService;
        IMapper _mapper;
        public ApproachController(IService<ApproachDTO> approachService)
        {
            _approachService = approachService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }
        // GET: api/Approach
        public IEnumerable<Approach> Get()
        {
            var approachesDTO = _approachService.GetAll();
            var approaches = _mapper.Map<List<Approach>>(approachesDTO);

            return approaches;
        }

        // GET: api/Approach/5
        public Approach Get(int id)
        {
            var approachDTO = _approachService.Get(id);
            var approach = _mapper.Map<Approach>(approachDTO);

            return approach;
        }

        // POST: api/Approach
        [HttpPost]
        public void Create([FromBody]Approach approach)
        {
            var approachDTO = _mapper.Map<ApproachDTO>(approach);
            _approachService.Create(approachDTO);
        }

        // PUT: api/Approach/5
        [HttpPut]
        public void Update(int id, [FromBody]Approach approach)
        {
            var approachDTO = _mapper.Map<ApproachDTO>(approach);
            _approachService.Update(approachDTO);
        }

        // DELETE: api/Approach/5
        public void Delete(int id)
        {
            _approachService.Remove(id);
        }
    }
}
