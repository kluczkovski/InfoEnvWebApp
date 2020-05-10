using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoEnvWebApp.Models;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.Extensions.Configuration;

namespace InfoEnvWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _conf;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _conf = configuration;
        }

        public IActionResult Index()
        {


            return View(new Info()
            {
                OSVersion = System.Environment.OSVersion.ToString(),
                FrameWorkVersion = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName,
                DateTime = DateTime.Now,
                VariableDeAmbienteManual =  System.Environment.GetEnvironmentVariable("INFO_VAR"),
                VariableDeAmbienteConfiguration = _conf.GetSection("Teste").GetValue<string>("Complex")




            }); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }


    public class Info
    {
        public string OSVersion { get; internal set; }
        public string FrameWorkVersion { get; internal set; }
        public DateTime DateTime { get; internal set; }
        public string VariableDeAmbienteManual { get; internal set; }
        public string VariableDeAmbienteConfiguration { get; internal set; }
    }
}
