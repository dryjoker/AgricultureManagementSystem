using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.Models
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext() : base("IdentityDbConn", false)
        {

        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}