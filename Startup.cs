using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Internal_Bursary.Startup))]
namespace Internal_Bursary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
