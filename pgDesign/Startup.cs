using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pgDesign.Startup))]
namespace pgDesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
