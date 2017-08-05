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
    [RoutePrefix("api/ApproachResult")]
    public class ApproachResultController : WoBaseController<ApproachResultController>
    {
        private IService<ApproachResultDTO> _service;
        private IMapper _mapper;
        public ApproachResultController(IService<ApproachResultDTO> service, ILoggerFactory loggerFactory) 
            : base(loggerFactory)
        {
            _service = service;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/ApproachResult/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Approach Result' by id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var approachResultDTO = _service.Get(id);

                if (approachResultDTO != null)
                {
                    var approachResult = _mapper.Map<ApproachResult>(approachResultDTO);

                    LogInfoObjectToJson(approachResult);
                    return Ok<ApproachResult>(approachResult);
                }

                LoggerService.Info("There is no 'Approach Result' with Id = '{0}'", id);

                return NotFound();
            });
        }

        // GET: api/ApproachResult
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Approach Result'");

            return ExecuteRequest(() =>
            {
                var approachResultDTO = _service.GetAll();
                var approachResult = _mapper.Map<List<ApproachResult>>(approachResultDTO);

                LogInfoObjectToJson(approachResult);
                return Ok<List<ApproachResult>>(approachResult);
            });
        }

        // PUT: api/ApproachResult/5
        [HttpPut]
        public IHttpActionResult Save([FromBody]ApproachResult approachResult)
        {
            LogInfoObjectToJson(approachResult, "Saving 'ApproachResult':");

            return ExecuteRequest(() =>
            {
                var approachResultDTO = _mapper.Map<ApproachResultDTO>(approachResult);
                var result = approachResult.Id > 0
                            ? _service.Update(approachResultDTO)
                            : _service.Create(approachResultDTO);

                LogInfoObjectToJson(result, "Saving 'ApproachResult':");
                return Ok<IOperationResult>(result);
            });
        }

        // DELETE: api/ApproachResult/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'ApproachResult' with id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var result = _service.Delete(id);

                LoggerService.Info("'ApproachResult' was removed");
                return Ok<IOperationResult>(result);
            });
        }
    }
}
