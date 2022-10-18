using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Watchlist.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string GetCurrentUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
