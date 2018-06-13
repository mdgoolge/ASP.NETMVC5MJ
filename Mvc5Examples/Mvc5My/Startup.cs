using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5My.Startup))]
namespace Mvc5My
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
