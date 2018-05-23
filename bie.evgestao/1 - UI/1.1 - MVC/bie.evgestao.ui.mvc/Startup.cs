using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bie.evgestao.ui.mvc.Startup))]
namespace bie.evgestao.ui.mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
