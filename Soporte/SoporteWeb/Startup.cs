using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoporteWeb.Startup))]
namespace SoporteWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
