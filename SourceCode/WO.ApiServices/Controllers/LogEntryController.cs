using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Services;

namespace WO.ApiServices.Controllers
{
    public class LogEntryController : ApiController
    {
        IService<LogEntryDTO> _service;
        private IMapper _mapper;

        public LogEntryController(IService<LogEntryDTO> service)
        {
            _service = service;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/LogDb/5
        public IHttpActionResult Get(int id)
        {
            var errorDTO = _service.Get(id);
            if (errorDTO != null)
            {
                var error = _mapper.Map<LogEntry>(errorDTO);

                return Ok<LogEntry>(error);
            }

            return NotFound();
        }

        // GET: api/LogDb
        public IHttpActionResult GetAll()
        {
            var allErrors = _service.GetAll();
            var errors = _mapper.Map<List<LogEntry>>(allErrors);

            return Ok<List<LogEntry>>(errors);
        }
    }
}