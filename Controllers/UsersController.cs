using Microsoft.AspNetCore.Mvc;

namespace Equipment_accounting.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
