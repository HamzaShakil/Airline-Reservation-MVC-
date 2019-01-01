using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Airline_Reservation.Startup))]
namespace Airline_Reservation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
