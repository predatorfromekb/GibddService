using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GibddService.Startup))]
namespace GibddService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
