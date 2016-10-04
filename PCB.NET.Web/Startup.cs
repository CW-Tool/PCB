using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCB.NET.Web.Startup))]
namespace PCB.NET.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
