using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB
{
    public class PCBAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PCB";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "PCB",
                url: "PCB/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PCB.NET.Web.Areas.PCB.Controllers" }
                );
        }
    }
}