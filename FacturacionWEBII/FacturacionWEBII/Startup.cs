using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacturacionWEBII.Startup))]
namespace FacturacionWEBII
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
