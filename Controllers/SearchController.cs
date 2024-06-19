using Equipment_accounting.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipment_accounting.Controllers
{
 public class SearchController : Controller
 {
  private readonly EquipmentBDContext _context;
  public SearchController(EquipmentBDContext context)
  {
   _context = context;
  }
  public IActionResult Index()
  {
   return View();
  }

  [HttpGet]
  public IActionResult GetEquipmentByName(string equipmentName)
  {
   var equipments = _context.Equipment.Where(e => e.Name == equipmentName).Include(e => e.Category).Include(e => e.Auditory).ToList();
   return Json(equipments);
  }
 }
}
