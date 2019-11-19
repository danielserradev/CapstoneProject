using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentX.Startup))]
namespace RentX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
