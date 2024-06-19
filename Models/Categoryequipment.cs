using System.ComponentModel.DataAnnotations;

namespace Equipment_accounting.Models
{
 public partial class Categoryequipment
 {
  [Key]
  public int Id { get; set; }
  public string Name { get; set; } = null!;
 }
}
