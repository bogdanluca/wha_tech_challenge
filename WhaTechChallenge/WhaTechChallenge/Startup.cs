using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhaTechChallenge.Startup))]
namespace WhaTechChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
