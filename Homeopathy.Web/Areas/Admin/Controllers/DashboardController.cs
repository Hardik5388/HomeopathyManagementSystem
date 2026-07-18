using Homeopathy.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homeopathy.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        public IActionResult Index()
        {
            var userId = CurrentUserId;
            var email = CurrentUserEmail;
            return View();
        }
    }
}
