using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Organobusca_.Startup))]
namespace Organobusca_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
