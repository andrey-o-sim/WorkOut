﻿using System.Collections.Generic;
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
    public class SetController : WoBaseController<SetController>
    {
        private IService<SetDTO> _service;
        private IMapper _mapper;

        public SetController(IService<SetDTO> exerciseService, ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            _service = exerciseService;
            _mapper = AutoMapperWebApiConfiguration.MapperConfiguration.CreateMapper();
        }

        // GET: api/Set/5
        public IHttpActionResult Get(int id)
        {
            LoggerService.Info("Getting 'Set' by id = '{0}'", id);

            return ExecuteRequest(() =>
            {
                var setDTO = _service.Get(id);

                if (setDTO != null)
                {
                    var set = _mapper.Map<Set>(setDTO);

                    LogInfoObjectToJson(set);
                    return Ok<Set>(set);
                }

                LoggerService.Info("There is no 'Set' with Id = '{0}'", id);

                return NotFound();
            });
        }

        // GET: api/Set
        public IHttpActionResult GetAll()
        {
            LoggerService.Info("Getting all 'Sets'");

            return ExecuteRequest(() =>
            {
                var setsDTO = _service.GetAll();
                var sets = _mapper.Map<List<Set>>(setsDTO);

                LogInfoObjectToJson(sets);
                return Ok<List<Set>>(sets);
            });
        }

        // POST: api/Set
        [HttpPost]
        public IHttpActionResult Create([FromBody]Set set)
        {
            LogInfoObjectToJson(set, "Creating 'Set':");

            return ExecuteRequest(() =>
            {
                var setDTO = _mapper.Map<SetDTO>(set);

                var result = _service.Create(setDTO);

                LogInfoObjectToJson(result, "Created 'Set':");
                return Ok<IOperationResult>(result);
            });
        }

        // PUT: api/Set/5
        [HttpPut]
        public IHttpActionResult Update([FromBody]Set set)
        {
            LogInfoObjectToJson(set, "Updating 'Set':");

            return ExecuteRequest(() =>
            {
                var setDTO = _mapper.Map<SetDTO>(set);
                var result = _service.Update(setDTO);

                LogInfoObjectToJson(result, "Updated 'Set':");
                return Ok<IOperationResult>(result);
            });
        }

        // DELETE: api/Set/5
        public IHttpActionResult Delete(int id)
        {
            LoggerService.Info("Deleting 'Set' with id = '{0}'", id);

            return ExecuteRequest(() =>
            {

                var result = _service.Delete(id);

                LoggerService.Info("'Set' was removed");
                return Ok<IOperationResult>(result);
            });
        }
    }
}
