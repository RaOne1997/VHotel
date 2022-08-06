using MakeMyTrip.Models;
using MakeMyTrip.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MakeMyTrip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBooksServices _bookServices;
        public HomeController(ILogger<HomeController> logger,IBooksServices booksServices)
        {
            _logger = logger;
            _bookServices = booksServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy(int id)
        {
            _bookServices.GetallAsync();
            ViewBag.Privacy = id;
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}