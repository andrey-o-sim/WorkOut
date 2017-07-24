using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using WO.ApiServices.Configs;
using WO.ApiServices.Models;
using WO.Core.BLL.DTO;
using WO.Core.BLL.Interfaces;
using WO.Core.BLL.Services;
using WO.LoggerFactory;
using System;
using WO.Core.BLL.Interfaces.Services;

namespace WO.ApiServices.Controllers
{
    public class ApproachController : WoBaseController<ApproachController>
    {
        private IApproachService _service;
        private IMapper _mapper;

        public ApproachController(IApproachService approachService, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            _service = approachService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Approach/5
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Approach' by id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var approachDTO = _service.Get(id);
                if (approachDTO != null)
                {
                    var approach = _mapper.Map<Approach>(approachDTO);

                    LogInfoObjectToJson(approach);
                    return Ok<Approach>(approach);
                }

                LoggerService.Info("There is no 'Approach' with Id = '{0}'", id);

                return NotFound();
            });
        }

        // GET: api/Approach
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Approaches'");

            return ExecuteRequest(() =>
            {
                var approachesDTO = _service.GetAll();
                var approaches = _mapper.Map<List<Approach>>(approachesDTO);

                LogInfoObjectToJson(approaches);
                return Ok<List<Approach>>(approaches);
            });
        }

        // PUT: api/Approach/5
        [HttpPut]
        public IHttpActionResult Save([FromBody]Approach approach)
        {
            LogInfoObjectToJson(approach, "Saving 'Approach':");

            return ExecuteRequest(() =>
            {
                var approachDTO = _mapper.Map<ApproachDTO>(approach);
                var result = approach.Id > 0 
                            ? _service.Update(approachDTO)
                            : _service.Create(approachDTO);

                LogInfoObjectToJson(result, "Saving 'Approach':");
                return Ok<IOperationResult>(result);
            });
        }

        // DELETE: api/Approach/5
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'Approach' with id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var result = _service.Delete(id);

                LoggerService.Info("'Approach' was removed");
                return Ok<IOperationResult>(result);
            });
        }

        [Route("api/Approach/GenerateApproachesForSet")]
        public IHttpActionResult GenerateApproachesForSet(Set set)
        {
            string logMessage = set.Id > 0
                ? string.Format("Genereting Approaches for Set Id = {0}", set.Id)
                : "Genereting Approaches for New Set";

            LoggerService.Info(logMessage);

            return ExecuteRequest(() =>
            {
                var setDTO = _mapper.Map<SetDTO>(set);

                var result = _service.GenerateApproachesForSet(setDTO);
                var approaches = _mapper.Map<List<Approach>>(result);

                approaches.ForEach(ap => set.Approaches.Add(ap));

                LoggerService.Info("{0} Approaches were generated", set.Approaches.Count);
                return Ok<Set>(set);
            }, true);
        }
    }
}
