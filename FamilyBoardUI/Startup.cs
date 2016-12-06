using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyBoardUI.Startup))]
namespace FamilyBoardUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
