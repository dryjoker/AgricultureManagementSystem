using AgricultureManagementSystem.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AgricultureManagementSystem
{
    //How can customize Asp.net Identity 2 username already taken validation message?
    //https://stackoverflow.com/questions/27655578/how-can-customize-asp-net-identity-2-username-already-taken-validation-message
    //https://forums.asp.net/t/2026833.aspx?How+can+customize+Asp+net+Identity+2+username+already+taken+validation+message+


    public class CustomUserValidator : UserValidator<User>
    {
        private UserManager<User> _userManager;

        public CustomUserValidator(UserManager mgr) : base(mgr)
        {
            _userManager = mgr;
        }

        public override async Task<IdentityResult> ValidateAsync(User user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            int cntAccount = _userManager.Users.Where(n => n.Account == user.Account).Count();
            if (cntAccount > 0)
            {
                var errors = result.Errors.ToList();
                //errors.Add("This Account Name already exists");
                result = new IdentityResult(errors);
            }
            return result;
        }

    }
}