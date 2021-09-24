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
                    string verify_code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var verify_EmailUrl = Url.Action("ConfirmEmail", "Register", new { userId = user.Id, code = verify_code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "新註冊用戶信箱開通", "請點擊如下連結 < a href =\"" + verify_EmailUrl + "\">Here</a>來確認你的帳戶");
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