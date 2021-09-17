using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthTokenExample.Startup))]

namespace AuthTokenExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Install-Package Microsoft.Owin.Cors
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureAuth(app);
        }
    }
}