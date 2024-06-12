namespace Equipment_accounting.Models
{
 public partial class Equipment
 {
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public DateOnly Receiptdate { get; set; }
  public DateOnly Dateaddedormoved { get; set; }
  public byte[]? Photo { get; set; }
  public byte[] Qrcode { get; set; } = null!;
  public int? DocumentId { get; set; }
  public int? AuditoryId { get; set; }
  public int? CategoryId { get; set; }

  public virtual Audience? Auditory { get; set; }
  public virtual Categoryequipment? Category { get; set; }
  public virtual Documentsequipment? Document { get; set; }
 }
}
