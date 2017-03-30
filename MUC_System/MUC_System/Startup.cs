using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MUC_System.Startup))]
namespace MUC_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
