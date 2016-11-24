using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTallerMecanico.Startup))]
namespace WebTallerMecanico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
