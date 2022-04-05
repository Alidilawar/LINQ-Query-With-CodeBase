using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LINQwithASP.NETMVC.Startup))]
namespace LINQwithASP.NETMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
