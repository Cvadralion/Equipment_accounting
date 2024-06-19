using System.ComponentModel.DataAnnotations;

namespace Equipment_accounting.Models
{
    public partial class Documentsequipment
    {
        [Key]
        public int Id { get; set; }
        public byte[] Scan { get; set; } = null!;
    }
}
