using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_MTY.Startup))]
namespace E_MTY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
