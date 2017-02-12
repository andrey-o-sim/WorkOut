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
    public class SetController : ApiController
    {
        IService<SetDTO> _setService;
        IMapper _mapper;

        public SetController(IService<SetDTO> exerciseService)
        {
            _setService = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }
        // GET: api/Set
        public IEnumerable<Set> Get()
        {
            var setsDTO = _setService.GetAll();
            var sets = _mapper.Map<List<Set>>(setsDTO);

            return sets;
        }

        // GET: api/Set/5
        public Set Get(int id)
        {
            var setDTO = _setService.Get(id);
            var set = _mapper.Map<Set>(setDTO);

            return set;
        }

        // POST: api/Set
        [HttpPost]
        public void Create([FromBody]Set set)
        {
            var setDTO = _mapper.Map<SetDTO>(set);
            _setService.Create(setDTO);
        }

        // PUT: api/Set/5
        [HttpPut]
        public void Update(int id, [FromBody]Set set)
        {
            var setDTO = _mapper.Map<SetDTO>(set);
            _setService.Update(setDTO);
        }

        // DELETE: api/Set/5
        public void Delete(int id)
        {
            _setService.Remove(id);
        }
    }
}
