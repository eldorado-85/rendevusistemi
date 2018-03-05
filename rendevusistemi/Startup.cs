using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rendevusistemi.Startup))]
namespace rendevusistemi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
