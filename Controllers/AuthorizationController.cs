using Equipment_accounting.DataBase;
using Equipment_accounting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Equipment_accounting.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EquipmentBDContext _context;

        public AuthorizationController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            EquipmentBDContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
           var response = new LoginViewModel();
           return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserName()
        {
            var login = base.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(login);
            return Json(user.Name + " " + user.Surname);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            this.SignOut();

            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            // Поиск пользователя по login
            var user = await _userManager.FindByNameAsync(loginViewModel.Login);

            // Проверка пользователя
            if (user == null)
            {
                TempData["Error"] = "Нет пользователя с таким логином";
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
   if (user.UserName.Contains("tech"))
   {
    return RedirectToAction("Index", "Management");
   }
   else if (user.UserName.Contains("admin"))
   {
    return RedirectToAction("Index", "Review");
   }
   else if (user.UserName.Contains("teacher"))
   {
    return RedirectToAction("Index", "Review");
   }
   else
   {
    return RedirectToAction("Index", "Review");
   }
  }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Authorization");
        }
    }
}