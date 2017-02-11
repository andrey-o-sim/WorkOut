using Ninject.Web.Common;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WO.ApiServices.App_Start;
using Ninject;
using Ninject.Modules;
using WO.Core.Data.Bindings;
using WO.ApiServices.Bindings;
using WO.Core.Data.Configs;
using Ninject.Web.WebApi;

namespace WO.ApiServices
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAutoMapper();
        }

        private void ConfigureAutoMapper()
        {
            AutoMapperWebApiConfiguration.RegisterMappings();
            AutoMapperDataConfiguration.RegisterMappings();
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            var modules = new List<INinjectModule>
            {
                new DataBindings(),
                new ApiBindings()
            };
            kernel.Load(modules);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }
    }
}
