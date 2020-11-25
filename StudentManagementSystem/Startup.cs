using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentManagementSystem.Startup))]
namespace StudentManagementSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
