using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using UtilityToolbox.iTask.Web.Infrastructure;
using System.Web.Http;

[assembly: OwinStartup(typeof(UtilityToolbox.iTask.Web.Startup))]

namespace UtilityToolbox.iTask.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            ConfigureAuth(app);
        }
    }
}
