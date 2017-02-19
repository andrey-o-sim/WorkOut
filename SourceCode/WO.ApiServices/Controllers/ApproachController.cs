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
        private IService<ApproachDTO> _approachService;
        private IMapper _mapper;

        public ApproachController(IService<ApproachDTO> approachService)
        {
            _approachService = approachService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Approach/5
        public Approach Get(int id)
        {
            var approachDTO = _approachService.Get(id);
            var approach = _mapper.Map<Approach>(approachDTO);

            return approach;
        }

        // GET: api/Approach
        public IEnumerable<Approach> GetAll()
        {
            var approachesDTO = _approachService.GetAll();
            var approaches = _mapper.Map<List<Approach>>(approachesDTO);

            return approaches;
        }

        // POST: api/Approach
        [HttpPost]
        public IOperationResult Create([FromBody]Approach approach)
        {
            var approachDTO = _mapper.Map<ApproachDTO>(approach);
            return _approachService.Create(approachDTO);
        }

        // PUT: api/Approach/5
        [HttpPut]
        public IOperationResult Update(int id, [FromBody]Approach approach)
        {
            var approachDTO = _mapper.Map<ApproachDTO>(approach);
            return _approachService.Update(approachDTO);
        }

        // DELETE: api/Approach/5
        public IOperationResult Delete(int id)
        {
            return _approachService.Delete(id);
        }
    }
}
