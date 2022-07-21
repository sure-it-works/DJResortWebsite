using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DJResortWebsite.Startup))]
namespace DJResortWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
