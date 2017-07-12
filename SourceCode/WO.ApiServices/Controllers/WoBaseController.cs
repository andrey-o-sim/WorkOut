using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using WO.ApiServices.Models.Helper;
using WO.Core.BLL;
using WO.Core.BLL.Interfaces;
using WO.LoggerFactory;
using WO.LoggerService;

namespace WO.ApiServices.Controllers
{
    public class WoBaseController<T> : ApiController where T : class
    {
        protected IOperationResult DefaultOperatingResult = new OperationResult() { Succeed = false, ResultItemId = 0 };
        protected ILoggerService LoggerService;

        protected WoBaseController(ILoggerFactory loggerFactory)
        {
            LoggerService = loggerFactory.Create<T>();
        }

        protected void LogInfoObjectToJson(object data, string message = "")
        {
            var jsonResult = JsonConvert.SerializeObject(data);
            LoggerService.Info(string.Format("{0}{1}", message, jsonResult));
        }

        protected void LogWarningObjectToJson(object data, string message = "")
        {
            var jsonResult = JsonConvert.SerializeObject(data);
            LoggerService.Warn(string.Format("{0}{1}", message, jsonResult));
        }

        protected IHttpActionResult ExecuteRequest(Func<IHttpActionResult> function)
        {
            if (!ModelState.IsValid)
            {
                var errors = GetValidationErrors();
                LogWarningObjectToJson(errors);
                var jsonErrors = JsonConvert.SerializeObject(errors);
                return BadRequest(jsonErrors);
            }

            IHttpActionResult actionResult = null;
            try
            {
                actionResult = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LoggerService.ErrorException(ex, "Error during dataBase action");
                actionResult = BadRequest(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LoggerService.ErrorException(ex, "Request Error");
                actionResult = InternalServerError(ex);
            }

            return actionResult;
        }

        private IEnumerable<ValidationError> GetValidationErrors()
        {
            var errors = new List<ValidationError>();
            foreach (var modelStateValue in ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    errors.Add(new ValidationError { ErrorMessage = error.ErrorMessage });
                }
            }

            return errors;
        }
    }
}