using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPA_MVCAngular.Startup))]
namespace SPA_MVCAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
