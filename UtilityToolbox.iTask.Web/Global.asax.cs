using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using UtilityToolbox.iTask.Domain.Concrete;

namespace UtilityToolbox.iTask.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyConfig.RegisterDependencies(GlobalConfiguration.Configuration);

            //In production environment, we should use MigrateDatabaseToLatestVersion as an alternative
            Database.SetInitializer<TaskContext>(new CreateDatabaseIfNotExists<TaskContext>());
        }
    }
}
