using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CamionesApp.Startup))]
namespace CamionesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
