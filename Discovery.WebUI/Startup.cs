using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Discovery.WebUI.Startup))]
namespace Discovery.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
