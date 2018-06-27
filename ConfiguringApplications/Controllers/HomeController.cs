using ConfiguringApplications.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public ViewResult Index(bool throwException = false)
        {
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
