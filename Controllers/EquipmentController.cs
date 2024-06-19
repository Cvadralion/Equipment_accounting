using Equipment_accounting.DataBase;
using Equipment_accounting.Models;
using Equipment_accounting.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Equipment_accounting.Controllers;
[CustomAuthorizationFilter]
public class EquipmentController : Controller
{
 private readonly EquipmentBDContext _context;
 public EquipmentController(EquipmentBDContext context)
 {
  _context = context;
 }

 [HttpGet]
 public IActionResult Edit(int equipmentId)
 {
  var equipment = _context.Equipment.Where(e => e.Id == equipmentId).Include(e => e.Category).Include(e => e.Auditory).First();
  ViewBag.Categories = new SelectList(_context.Categoryequipments.ToList(), "Id", "Name");
  ViewBag.Auditory = new SelectList(_context.Audiences.ToList(), "Id", "Name");
  return View(new EditEquipmentViewModel()
  {
   Id = equipment.Id,
   Name = equipment.Name,
   AuditoryId = equipment.AuditoryId,
   CategoryId = equipment.CategoryId,
   Receiptdate = equipment.Receiptdate,
   Dateaddedormoved = equipment.Dateaddedormoved,
  });
 }

 [HttpPost]
 public async Task<IActionResult> Edit(EditEquipmentViewModel equipment)
{
    var receiptDate = DateTime.ParseExact(equipment.Receiptdate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
    var dateAddedOrMoved = DateTime.ParseExact(equipment.Dateaddedormoved, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

  var updatedEquipment = new Equipment()
  {
   Id = equipment.Id,
   Name = equipment.Name,
   AuditoryId = equipment.AuditoryId,
   CategoryId = equipment.CategoryId,
   Receiptdate = new DateOnly(receiptDate.Year, receiptDate.Month, receiptDate.Day),
   Dateaddedormoved = new DateOnly(dateAddedOrMoved.Year, dateAddedOrMoved.Month, dateAddedOrMoved.Day)
  };

    _context.Update(updatedEquipment);
    await _context.SaveChangesAsync();
    return RedirectToAction("Index", "Management");
}

 [HttpPost]
 public async Task<IActionResult> Delete(int Id)
 {
  var equipment = _context.Equipment.Where(e => e.Id == Id).First();
  _context.Equipment.Remove(equipment);
  await _context.SaveChangesAsync();
  return RedirectToAction("Index", "Management");
 }

 [HttpPost]
 public async Task<IActionResult> Add(Equipment equipment)
 {
  _context.Equipment.Add(equipment);
  await _context.SaveChangesAsync();
  return RedirectToAction("Index", "Management");
 }

 public class DocumentUploadViewModel
 {
  [Required]
  [DataType(DataType.Upload)]
  [Display(Name = "Document")]
  public IFormFile Document { get; set; }
 }
}
