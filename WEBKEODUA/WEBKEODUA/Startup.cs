using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBKEODUA.Startup))]
namespace WEBKEODUA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
