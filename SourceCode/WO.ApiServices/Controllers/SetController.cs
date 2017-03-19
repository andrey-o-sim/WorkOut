using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.ApiServices.Controllers.ViewModel;

namespace WO.ApiServices.Controllers
{
    public class SetController : ApiController
    {
        private IService<SetDTO> _service;
        private IMapper _mapper;

        public SetController(IService<SetDTO> exerciseService)
        {
            _service = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Set/5
        public IHttpActionResult Get(int id)
        {
            var setDTO = _service.Get(id);

            if (setDTO != null)
            {
                var set = _mapper.Map<Set>(setDTO);
                return Ok<Set>(set);
            }

            return NotFound();
        }

        // GET: api/Set
        public IHttpActionResult GetAll()
        {
            var setsDTO = _service.GetAll();
            var sets = _mapper.Map<List<Set>>(setsDTO);

            return Ok<List<Set>>(sets);
        }

        // POST: api/Set
        [HttpPost]
        public IHttpActionResult Create([FromBody]Set set)
        {
            var setViewModel = new SetViewModel();
            setViewModel.GetFullSetData(set);

            var setDTO = _mapper.Map<SetDTO>(set);

            var result = _service.Create(setDTO);

            return Ok<IOperationResult>(result);
        }

        // PUT: api/Set/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Set set)
        {
            var setDTO = _mapper.Map<SetDTO>(set);
            var result = _service.Update(setDTO);

            return Ok<IOperationResult>(result);
        }

        // DELETE: api/Set/5
        public IHttpActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Ok<IOperationResult>(result);
        }
    }
}
