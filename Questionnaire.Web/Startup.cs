using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Questionnaire.Web.Startup))]
namespace Questionnaire.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
