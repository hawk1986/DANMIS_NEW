using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DANMIS_NEW.Startup))]
namespace DANMIS_NEW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}