using ClubSport.Infrastrucher;
using ClubSport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClubSport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
    [Microsoft.AspNetCore.Mvc.Route("api/TestController")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class TestController 
    {
        [HttpPost("act")]
        public string ActionTest(string test="Hello")
        {
           
            return test + "Tested!";
        }

    }
    }
