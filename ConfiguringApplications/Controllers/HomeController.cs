using ConfiguringApplications.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConfiguringApplications.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService _uptimeService;

        public HomeController(UptimeService uptimeService)
        {
            _uptimeService = uptimeService;
        }

        public ViewResult Index() => View(new Dictionary<string, string>()
        {
            ["Message"] = "This is the Index Action",
            ["Uptime"] = $"{_uptimeService.Uptime}ms"
        });
    }
}
