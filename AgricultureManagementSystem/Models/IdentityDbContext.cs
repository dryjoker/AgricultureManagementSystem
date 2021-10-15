using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.Models
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext() : base("IdentityDbConn", false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //must at the begin
            //modelBuilder.Entity<User>().ToTable("CustomUsers");
            //modelBuilder.Entity<IdentityRole>().ToTable("CustomRoles");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("CustomUserRoles");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("CustomUserClaims");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("CustomUserLogins");
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}