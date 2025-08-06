using BarberHub.Web.ViewModels.Error;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BarberHub.Web.Controllers
{
    public class ErrorController : BaseController
    {

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //[HttpGet("/Home/NotFound")]
        //public IActionResult NotFound(int statusCode)
        //{
        //    ViewData["StatusCode"] = statusCode;
        //    return View();
        //}

        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View("NotFound");
        }

        [Route("Error/500")]
        public IActionResult Error500()
        {
            return View("ServerError");
        }
    }
}
