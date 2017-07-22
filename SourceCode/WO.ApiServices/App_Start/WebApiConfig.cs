using FluentValidation.WebApi;
using System.Web.Http;

namespace WO.ApiServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
