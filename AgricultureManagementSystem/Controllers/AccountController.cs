using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Edit()
        {
            return View();
        }

    }
}