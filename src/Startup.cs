using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Microbloging.Startup))]
namespace Microbloging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
