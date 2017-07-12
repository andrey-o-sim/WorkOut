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

namespace WO.ApiServices.Controllers
{
    public class ApproachController : WoBaseController<ApproachController>
    {
        private IService<ApproachDTO> _service;
        private IMapper _mapper;

        public ApproachController(IService<ApproachDTO> approachService, ILoggerFactory loggerFactory)
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
                else
                {
                    LoggerService.Info("There is no 'Approach' with Id = '{0}'", id);
                }

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

        // POST: api/Approach
        [HttpPost]
        public IHttpActionResult Create([FromBody]Approach approach)
        {
            LogInfoObjectToJson(approach, "Creating 'Approach':");

            return ExecuteRequest(() =>
            {
                var approachDTO = _mapper.Map<ApproachDTO>(approach);
                var result = _service.Create(approachDTO);

                LogInfoObjectToJson(result, "Created 'Approach':");
                return Ok<IOperationResult>(result);
            });
        }

        // PUT: api/Approach/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Approach approach)
        {
            LogInfoObjectToJson(approach, "Updating 'Approach':");

            return ExecuteRequest(() =>
            {
                var approachDTO = _mapper.Map<ApproachDTO>(approach);
                var result = _service.Update(approachDTO);

                LogInfoObjectToJson(result, "Updated 'Approach':");
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
    }
}
