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
                    //string verify_code_encode = HttpUtility.UrlEncode(verify_code);
                    var verify_EmailUrl = Url.Action("ConfirmEmail", "Register", new { userId = user.Id, code = verify_code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "新註冊用戶信箱開通", "請點擊如下連結 <a href =\"" + verify_EmailUrl + "\">Here</a>來確認你的帳戶");
                    return RedirectToAction("Index", "Login");
                }
                AddErrors(result);
            }

            //return RedirectToAction("Index", "Register", addUserViewModel);
            return View(addUserViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                return View("Error");
            }

            var _user = await UserManager.FindByIdAsync(userId);
            if (_user == null)
            {
                return View("Error");
            }
            _user.IsFirstTimeRequest = false;
            await UserManager.UpdateAsync(_user);
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
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