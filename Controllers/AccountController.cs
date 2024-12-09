using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
             
                var result1 = await  signInManager.PasswordSignInAsync(model.Email, model.Password,true , false);
                if (result1.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "invalid Email or password attemp");
                }
            }
            return View(model);
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Registration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {

                var user = new IdentityUser()
                {
                    UserName = model.Email,
                    Email = model.Email
                };

             var result =await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }



            }

            return View(model);
        }
    }
}
