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

        // �������� �� ������ 404 (Not Found)
        [HttpGet("/Home/NotFound")] // ������� ��, �� ����� ������� � ���� � UseStatusCodePagesWithReExecute
        public IActionResult NotFound(int statusCode) // ������ statusCode �� {0} ������������
        {
            // ����� �� ������ statusCode ���, ��� ����� �� ������ 404 ������
            ViewData["StatusCode"] = statusCode;
            return View();
        }
    }
}
