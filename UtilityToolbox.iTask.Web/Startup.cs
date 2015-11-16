using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using UtilityToolbox.iTask.Web.Infrastructure;

[assembly: OwinStartup(typeof(UtilityToolbox.iTask.Web.Startup))]

namespace UtilityToolbox.iTask.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
            ConfigureAuth(app);
        }
    }
}
