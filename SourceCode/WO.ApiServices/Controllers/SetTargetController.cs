using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.LoggerFactory;

namespace WO.ApiServices.Controllers
{
    [RoutePrefix("api/SetTarget")]
    public class SetTargetController : WoBaseController<SetTargetController>
    {
        private IService<SetTargetDTO> _service;
        private IMapper _mapper;
        public SetTargetController(IService<SetTargetDTO> service,ILoggerFactory loggerFactory) 
            : base(loggerFactory)
        {
            _service = service;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/SetTarget/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Set Target' by id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var setTargetDTO = _service.Get(id);

                if (setTargetDTO != null)
                {
                    var setTarget = _mapper.Map<SetTarget>(setTargetDTO);

                    LogInfoObjectToJson(setTarget);
                    return Ok<SetTarget>(setTarget);
                }

                LoggerService.Info("There is no 'Set Target' with Id = '{0}'", id);

                return NotFound();
            });
        }

        // GET: api/SetTarget
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Set Target'");

            return ExecuteRequest(() =>
            {
                var setTargetDTO = _service.GetAll();
                var setTarget = _mapper.Map<List<SetTarget>>(setTargetDTO);

                LogInfoObjectToJson(setTarget);
                return Ok<List<SetTarget>>(setTarget);
            });
        }

        // PUT: api/SetTarget/5
        [HttpPut]
        public IHttpActionResult Save([FromBody]SetTarget setTarget)
        {
            LogInfoObjectToJson(setTarget, "Saving 'SetTarget':");

            return ExecuteRequest(() =>
            {
                var setTargetDTO = _mapper.Map<SetTargetDTO>(setTarget);
                var result = setTarget.Id > 0
                            ? _service.Update(setTargetDTO)
                            : _service.Create(setTargetDTO);

                LogInfoObjectToJson(result, "Saving 'SetTarget':");
                return Ok<IOperationResult>(result);
            });
        }

        // DELETE: api/SetTarget/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'SetTarget' with id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var result = _service.Delete(id);

                LoggerService.Info("'SetTarget' was removed");
                return Ok<IOperationResult>(result);
            });
        }
    }
}