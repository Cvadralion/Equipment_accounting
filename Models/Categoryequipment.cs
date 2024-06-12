namespace Equipment_accounting.Models
{
 public partial class Categoryequipment
 {
  public Categoryequipment()
  {
   Equipment = new HashSet<Equipment>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;

  public virtual ICollection<Equipment> Equipment { get; set; }
 }
}
