using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AgricultureManagementSystem.Models
{
    public class User : IdentityUser
    {
        public virtual string Account { get; set; }
        public virtual string Region { get; set; }

        public virtual bool IsFirstTimeRequest { get; set; }

        public User()
        {
            this.IsFirstTimeRequest = true;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

    }
}