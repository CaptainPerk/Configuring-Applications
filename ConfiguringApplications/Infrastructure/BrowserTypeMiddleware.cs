using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApplications.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private readonly RequestDelegate _nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("edge"));
            await _nextDelegate.Invoke(httpContext);
        }
    }
}
