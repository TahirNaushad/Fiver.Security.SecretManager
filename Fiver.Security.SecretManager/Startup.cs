using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Fiver.Security.SecretManager
{
    public class Startup
    {
        public static IConfiguration Config { get; private set; }

        public Startup(
            IConfiguration config)
        {
            Config = config;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Config);
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHelloWorld();
        }
    }
}
