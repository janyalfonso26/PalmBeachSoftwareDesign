using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PalmBeachWebDesign.Startup))]
namespace PalmBeachWebDesign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
