using AgricultureManagementSystem.Models;
using AgricultureManagementSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AgricultureManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager _userManager;
        public UserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = addUserViewModel.Account,
                    Account = addUserViewModel.Account,
                    Email = addUserViewModel.Email,
                    Region = addUserViewModel.Region
                };
                
                var result = await UserManager.CreateAsync(user, addUserViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                AddErrors(result);
            }

            //return RedirectToAction("Index", "Register", addUserViewModel);
            return View(addUserViewModel);
        }

        private void AddErrors(IdentityResult identityResult)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

    }
}