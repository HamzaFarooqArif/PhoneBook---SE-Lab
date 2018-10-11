using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppPhoneBook.Startup))]
namespace WebAppPhoneBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
