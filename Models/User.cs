using Microsoft.AspNetCore.Identity;

namespace Equipment_accounting.Models
{
    public class User : IdentityUser
    {
  public string Name { set; get; }
  public string Surname { set; get; }
    }
}
