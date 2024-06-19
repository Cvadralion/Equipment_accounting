using Equipment_accounting.DataBase;
using Equipment_accounting.Models;
using Equipment_accounting.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Equipment_accounting.Controllers
{
    [CustomAuthorizationFilter]

    public class ReviewController : Controller
    {
        private readonly EquipmentBDContext _context;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ILogger<ReviewController> logger, EquipmentBDContext context)
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

    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private readonly string _format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (DateOnly.TryParseExact(dateString, _format, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
            throw new JsonException($"Unable to convert \"{dateString}\" to {nameof(DateOnly)}");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}

