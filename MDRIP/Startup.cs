using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MDRIP.Startup))]
namespace MDRIP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
