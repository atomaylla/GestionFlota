using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSIGestionFlota.Startup))]
namespace WebSIGestionFlota
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
