using System;
using System.Web;
using System.Web.Mvc;

namespace PCB.NET.Web.Filter
{
    public class CacheAttribute : ActionFilterAttribute
    {
        public int Duration { get; set; }

        public CacheAttribute()
        {
            Duration = 3600;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Duration <= 0) return;

            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            TimeSpan cacheDuration = TimeSpan.FromSeconds(Duration);
            cache.SetCacheability(HttpCacheability.Public);
            cache.SetExpires(DateTime.Now.Add(cacheDuration));
            cache.SetMaxAge(cacheDuration);
            cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
        }
    }
}