using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Fiver.Security.SecretManager
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware>();
        }
    }

    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;
        private readonly AppSettings settings;

        public HelloWorldMiddleware(
            RequestDelegate next,
            IOptions<AppSettings> options)
        {
            this.next = next;
            this.settings = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var jsonSettings = JsonConvert.SerializeObject(this.settings);
            await context.Response.WriteAsync(jsonSettings);
        }
    }
}
