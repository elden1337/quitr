using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quitr2.Startup))]
namespace Quitr2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
