namespace Equipment_accounting.Models
{
 public partial class Audience
 {
  public Audience()
  {
   Equipment = new HashSet<Equipment>();
  }

  public int Id { get; set; }
  public int Number { get; set; }
  public string Name { get; set; } = null!;

  public virtual ICollection<Equipment> Equipment { get; set; }
 }
}
