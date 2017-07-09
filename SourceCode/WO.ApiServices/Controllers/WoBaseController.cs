using Newtonsoft.Json;
using System;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
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

        protected IHttpActionResult ExecuteRequest(Func<IHttpActionResult> function)
        {
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
    }
}