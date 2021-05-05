using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwentyTwoVzn.Startup))]
namespace TwentyTwoVzn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
