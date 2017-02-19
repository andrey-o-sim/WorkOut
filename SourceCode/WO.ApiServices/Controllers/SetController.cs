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
    public class SetController : ApiController
    {
        private IService<SetDTO> _setService;
        private IMapper _mapper;

        public SetController(IService<SetDTO> exerciseService)
        {
            _setService = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Set/5
        public Set Get(int id)
        {
            var setDTO = _setService.Get(id);
            var set = _mapper.Map<Set>(setDTO);

            return set;
        }

        // GET: api/Set
        public IEnumerable<Set> GetAll()
        {
            var setsDTO = _setService.GetAll();
            var sets = _mapper.Map<List<Set>>(setsDTO);

            return sets;
        }

        // POST: api/Set
        [HttpPost]
        public IOperationResult Create([FromBody]Set set)
        {
            var setDTO = _mapper.Map<SetDTO>(set);
            return _setService.Create(setDTO);
        }

        // PUT: api/Set/5
        [HttpPut]
        public IOperationResult Update(int id, [FromBody]Set set)
        {
            var setDTO = _mapper.Map<SetDTO>(set);
            return _setService.Update(setDTO);
        }

        // DELETE: api/Set/5
        public IOperationResult Delete(int id)
        {
            return _setService.Delete(id);
        }
    }
}
