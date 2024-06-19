namespace Equipment_accounting.Models
{
    public partial class EditEquipmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly? Receiptdate { get; set; }
        public DateOnly? Dateaddedormoved { get; set; }
        public int? AuditoryId { get; set; }
        public int? CategoryId { get; set; }

        public int? DocumentId { get; set; }
    }
}
