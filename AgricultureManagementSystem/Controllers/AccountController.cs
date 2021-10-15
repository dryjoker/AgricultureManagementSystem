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
    public class AccountController : Controller
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

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            var users = UserManager.Users.ToList();
            return View(users);
        }

        // GET: Edit
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            User _user = UserManager.FindById(id);
            if (_user == null)
            {
                return HttpNotFound();
            }

            var editUserViewModel = new EditUserViewModel()
            {
                Account = _user.Account,
                Email = _user.Email,
                Region = _user.Region
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(id))
            {
                User _user = UserManager.FindById(id);
                _user.Account = editUserViewModel.Account;
                _user.Email = editUserViewModel.Email;
                _user.Region = editUserViewModel.Region;

                var result = await UserManager.UpdateAsync(_user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");                    
                }
                AddErrors(result);
            }
            return View(editUserViewModel);
        }




        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            User _user = UserManager.FindById(id);
            if (_user == null)
            {
                return HttpNotFound();
            }

            var result = await UserManager.DeleteAsync(_user);
            if (!result.Succeeded)
            {
                AddErrors(result);
            }
            return RedirectToAction("Index", "Account");
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