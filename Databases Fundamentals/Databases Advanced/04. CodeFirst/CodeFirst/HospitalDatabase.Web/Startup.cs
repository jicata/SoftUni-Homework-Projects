using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalDatabase.Web.Startup))]
namespace HospitalDatabase.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
