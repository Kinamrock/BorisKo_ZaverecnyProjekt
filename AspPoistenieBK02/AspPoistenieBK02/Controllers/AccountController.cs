using AspPoistenieBK.Controllers;
using AspPoistenieBK02.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspPoistenieBK02.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController( UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #region LOGIN
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewData["RetrunUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var validationResult = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if(validationResult.Succeeded)
                    return RedirectToLocal(returnUrl); //uspesne prihlasenie
                else
                {
                    //ak overenie neprejde
                    ViewBag.LoginError = StringCommon.msg003_WrongLogInData;
                    //ModelState.AddModelError(string.Empty, StringCommon.msg003_WrongLogInData);
                    return View(model);
                }
            }
            //ak boli odoslane zle udaje alebo nevzplnene udaje
            return View(model);
        }
        #endregion

        #region LOGOUT
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion

        #region REGISTER
        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            Console.WriteLine("Register is called");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
 
                foreach (var error in result.Errors)
                {
                    
                    if (error.Description.Contains("is already taken"))
                    {
                        ViewBag.RegisterError = string.Format(StringCommon.msg004_EmailAddressIsTaken, model.Email);
                        //asp-validation-summary = "All" vyuzijem len a len pre info o uz registrovanom maily. Cesta najmensie odporu, neviem kde inde to teraz spravit
                        //error.Description = string.Format(StringCommon.msg004_EmailAddressIsTaken, model.Email);
                        //ModelState.AddModelError("RegisteredEmail", error.Description);
                    }
                }
                
            }

            return View(model);
        }
        #endregion


    }
}
