using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigsHub.Startup))]
namespace GigsHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
