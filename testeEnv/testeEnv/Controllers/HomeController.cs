using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using testeEnv.Models;

namespace testeEnv.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var t = configuration.GetSection("ConnectionStrings:Local").Value;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
