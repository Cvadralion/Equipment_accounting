using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Equipment_accounting.Utils
{
 public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
 {
  public string[] Roles { get; set; }

  public CustomAuthorizationFilterAttribute()
  {
  }

  public CustomAuthorizationFilterAttribute(string roles)
  {
   Roles = roles.Split(',');
  }

  public void OnAuthorization(AuthorizationFilterContext context)
  {
   var user = context.HttpContext.User;
   if (!IsAuthorized(user))
   {
    context.Result = new RedirectToRouteResult(new RouteValueDictionary
    {
        { "controller", "Authorization" },
        { "action", "Index" }
    });
    return;
   }

   if (Roles != null && Roles.Length > 0)
   {
    if (!IsInRole(user))
    {
    }
   }
  }

  private bool IsAuthorized(ClaimsPrincipal user) => user.Identity.IsAuthenticated;

  private bool IsInRole(ClaimsPrincipal user)
  {
   foreach (string role in Roles)
   {
    if (user.IsInRole(role))
    {
     return true;
    }
   }
   return false;
  }
 }
}
