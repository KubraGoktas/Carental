using CarentalLibrary.DataAcces.Context;
using CarentalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarentalWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarentalContext _CarentalContext;

        public HomeController(ILogger<HomeController> logger, CarentalContext carentalContext)
        {
            _logger = logger;
            _CarentalContext = carentalContext;
        }

        public IActionResult Index()
        {
            var carentallist=_CarentalContext.rentals.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Account()
        {
            var customers = _CarentalContext.customers.ToList();
            ViewBag.customers = customers;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
