using Equipment_accounting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.WebPages.Html;

namespace Equipment_accounting.Controllers
{
 public class AuthorizationController : Controller
 {
  public IActionResult Index()
  {
   return View();
  }
 }
 [HttpPost]
 public async Task<IActionResult> Login(LoginViewModel loginViewModel)
 {
  if (!ModelState.IsValid)
  {
   return View(loginViewModel);
  }

  // Поиск пользователя по email
  var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

  // Проверка пользователя
  if (user == null)
  {
   TempData["Error"] = "Нет пользователя с таким email-адресом";
   return View(loginViewModel);
  }

  // Проверка пароля
  var isValidPassword = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
  if (!isValidPassword)
  {
   TempData["Error"] = "Неверный пароль";
   return View(loginViewModel);
  }


  // Попытка войти в систему
  var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password,
      isPersistent: true, lockoutOnFailure: false);

  if (!signInResult.Succeeded)
  {
   TempData["Error"] = "Что-то пошло не так";
   return View(loginViewModel);
  }
  return RedirectToAction("Index", "Movie");
 }
}
