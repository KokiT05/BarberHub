using BarberHub.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BarberHub.Web.Controllers
{
    public class HomeController : BaseController
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

        // Действие за грешки 404 (Not Found)
        [HttpGet("/Home/NotFound")] // Уверете се, че пътят съвпада с този в UseStatusCodePagesWithReExecute
        public IActionResult NotFound(int statusCode) // Приема statusCode от {0} плейсхолдъра
        {
            // Можеш да логваш statusCode тук, ако искаш да следиш 404 грешки
            ViewData["StatusCode"] = statusCode;
            return View();
        }
    }
}
