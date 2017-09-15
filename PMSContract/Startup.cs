using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMSContract.Startup))]
namespace PMSContract
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
