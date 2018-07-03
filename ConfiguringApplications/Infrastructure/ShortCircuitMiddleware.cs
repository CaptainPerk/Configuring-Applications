using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConfiguringApplications.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
