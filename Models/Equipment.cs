using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equipment_accounting.Models
{
    public partial class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Receiptdate { get; set; }
        public DateOnly Dateaddedormoved { get; set; }
        public string? Photo { get; set; }
        public byte[]? Qrcode { get; set; }
        [ForeignKey("Documentsequipment")]
        public int? DocumentId { get; set; }
        [ForeignKey("Audience")]
        public int? AuditoryId { get; set; }
        [ForeignKey("Categoryequipment")]
        public int? CategoryId { get; set; }

        public virtual Audience? Auditory { get; set; }
        public virtual Categoryequipment? Category { get; set; }
        public virtual Documentsequipment? Document { get; set; }
    }
}
