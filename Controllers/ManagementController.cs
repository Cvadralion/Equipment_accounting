using Microsoft.AspNetCore.Mvc;

namespace Equipment_accounting.Controllers
{
 public class ManagementController : Controller
 {
  public IActionResult Index()
  {
   return View();
  }
 }
}
