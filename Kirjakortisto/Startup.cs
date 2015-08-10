using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kirjakortisto.Startup))]
namespace Kirjakortisto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
