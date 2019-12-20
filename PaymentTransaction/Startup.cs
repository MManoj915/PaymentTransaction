using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentTransaction.Startup))]
namespace PaymentTransaction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
