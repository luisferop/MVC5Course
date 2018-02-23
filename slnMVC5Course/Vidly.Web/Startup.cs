using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly.Web.Startup))]
namespace Vidly.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
