using Homeopathy.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homeopathy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.SuperAdmin)]
    public abstract class AdminBaseController : Controller
    {
        protected string? CurrentUserId =>
        User.FindFirstValue(ClaimTypes.NameIdentifier);

        protected string? CurrentUserEmail =>
            User.Identity?.Name;

        protected string? CurrentUserRole =>
            User.FindFirstValue(ClaimTypes.Role);
    }
}
