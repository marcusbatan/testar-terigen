using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hemsida.Startup))]
namespace Hemsida
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
