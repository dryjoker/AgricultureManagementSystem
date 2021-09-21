using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.Models
{
    public class User : IdentityUser
    {
        public virtual string Account { get; set; }
        public virtual string Region { get; set; }
    }
}