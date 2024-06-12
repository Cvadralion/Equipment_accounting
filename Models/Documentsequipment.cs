namespace Equipment_accounting.Models
{
 public partial class Documentsequipment
 {
  public Documentsequipment()
  {
   Equipment = new HashSet<Equipment>();
  }

  public int Id { get; set; }
  public byte[] Scan { get; set; } = null!;

  public virtual ICollection<Equipment> Equipment { get; set; }
 }
}
