using Microsoft.AspNetCore.Mvc;

namespace LibraryVue.Server.Controllers
{
    public class AuthenticateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
