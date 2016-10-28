using NLog;
using NLog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PCB.NET.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            string nlogPath = Server.MapPath("nlog-web.log");
            InternalLogger.LogFile = nlogPath;
            InternalLogger.LogLevel = NLog.LogLevel.Trace;


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //MappingConfig.RegisterMapping();
        }
    }
}
