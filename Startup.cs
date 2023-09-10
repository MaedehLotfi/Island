using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Island.Startup))]
namespace Island
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
