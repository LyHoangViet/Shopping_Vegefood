using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoping_vegefood.Models;
using Shoping_vegefood.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Shoping_vegefood.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly SignInManager<AppUserModel> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return LocalRedirect(loginVM.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Username or Password is invalid.");
            }

            // Ensure that the ReturnUrl is set in the model so it can be rendered in the view.
            loginVM.ReturnUrl = loginVM.ReturnUrl ?? "/";
            return View(loginVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUserModel { UserName = user.UserName, Email = user.Email };
                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    TempData["Success"] = "User created successfully";
                    return Redirect("/account/login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(user);
        }
    }
}
