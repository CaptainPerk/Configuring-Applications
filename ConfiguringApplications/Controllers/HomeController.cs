using ConfiguringApplications.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ConfiguringApplications.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService _uptimeService;
        private ILogger<HomeController> _logger;

        public HomeController(UptimeService uptimeService, ILogger<HomeController> logger)
        {
            _uptimeService = uptimeService;
            _logger = logger;
        }

        public ViewResult Index(bool throwException = false)
        {
            _logger.LogDebug($"Handled {Request.Path} at uptime {_uptimeService.Uptime}");

            if (throwException)
            {
                throw new NullReferenceException();    
            }

            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index Action",
                ["Uptime"] = $"{_uptimeService.Uptime}ms"
            });
        }

        public ViewResult Error() => View(nameof(Index), new Dictionary<string, string>
        {
            ["Message"] = "This is the Error Action"
        });
    }
}
