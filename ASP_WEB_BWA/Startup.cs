using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_WEB_BWA.Startup))]
namespace ASP_WEB_BWA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
