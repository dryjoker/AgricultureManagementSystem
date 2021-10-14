using AgricultureManagementSystem.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private SignInManager _signInManager;
        public SignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<SignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string retUrl)
        {
            ViewBag.ReturnUrl = retUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel loginViewModel, string retUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var result = await SignInManager.PasswordSignInAsync(loginViewModel.Email, 
                loginViewModel.Password, loginViewModel.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(retUrl);
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = retUrl, RememberMe = loginViewModel.RememberMe });
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "無效的登入");
                    return View(loginViewModel);
            }
        }

        public ActionResult RedirectToLocal(string retUrl)
        {
            if (Url.IsLocalUrl(retUrl))
                return Redirect(retUrl);

            return RedirectToAction("Index", "Login");
        }


    }
}