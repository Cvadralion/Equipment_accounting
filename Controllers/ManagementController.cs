using Equipment_accounting.DataBase;
using Equipment_accounting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using Equipment_accounting.Utils;

namespace Equipment_accounting.Controllers
{
 [CustomAuthorizationFilter]
 public class ManagementController : Controller
 {
  private readonly EquipmentBDContext _context;
  private readonly ILogger<ReviewController> _logger;

  public ManagementController(ILogger<ReviewController> logger, EquipmentBDContext context)
  {
   _logger = logger;
   _context = context;
  }

  public async Task<IActionResult> Index()
  {
   var Auditories = await _context.Audiences.ToListAsync();
   return View(Auditories);
  }

  [HttpGet]
  public IActionResult GetEquipmentByAuditory(int auditoryId)
  {
   var equipments = _context.Equipment.Where(e => e.AuditoryId == auditoryId).Include(e => e.Category).ToList();
   return Json(equipments);
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
   return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
 }
}
