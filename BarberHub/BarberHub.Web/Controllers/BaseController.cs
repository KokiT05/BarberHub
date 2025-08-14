using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberHub.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {

        protected bool IsAuthenticated()
        {
            bool isAuthenticated = this.User.Identity?.IsAuthenticated ?? false;

            return isAuthenticated;

		}

        protected string? GetUserId()
        {
            string? userId = null;

            if (this.IsAuthenticated())
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}
