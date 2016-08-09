using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCB.NET.Startup))]
namespace PCB.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
