using Microsoft.Owin;
using Owin;
using TwentyTwoVzn.Models;

[assembly: OwinStartupAttribute(typeof(TwentyTwoVzn.Startup))]
namespace TwentyTwoVzn
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRole();
        }
    }
}
