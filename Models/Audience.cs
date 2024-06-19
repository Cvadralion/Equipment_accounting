using System.ComponentModel.DataAnnotations;

namespace Equipment_accounting.Models
{
    public partial class Audience
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = null!;
    }
}
