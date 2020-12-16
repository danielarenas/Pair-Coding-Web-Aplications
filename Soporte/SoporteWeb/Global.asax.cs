using SoporteWeb.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SoporteWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.CheckRoles();
            Utility.CheckSuperUser();
        }

        private void CheckRoles()
        {
            Utility.CheckRoles("Administrator");
            Utility.CheckRoles("Normal");
            
        }
    }
}
