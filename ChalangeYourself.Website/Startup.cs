using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChalangeYourself.Website.Startup))]
namespace ChalangeYourself.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
