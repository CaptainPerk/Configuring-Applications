using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApplications.Infrastructure
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public ErrorMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _nextDelegate.Invoke(httpContext);

            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
}
