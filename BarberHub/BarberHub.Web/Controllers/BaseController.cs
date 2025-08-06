using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
