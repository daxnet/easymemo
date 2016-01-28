using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyMemo.Web.Startup))]
namespace EasyMemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
