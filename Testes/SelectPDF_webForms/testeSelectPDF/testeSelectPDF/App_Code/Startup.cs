using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testeSelectPDF.Startup))]
namespace testeSelectPDF
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
