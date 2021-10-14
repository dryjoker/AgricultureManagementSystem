using AgricultureManagementSystem.Models;
using AgricultureManagementSystem.Public;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AgricultureManagementSystem
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {

        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore<User>(context.Get<Models.IdentityDbContext>()));
            //manager.UserValidator = new UserValidator<User>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true
            //};

            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.EmailService = new EmailService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("EmailConfirm"));
            }

            return manager;
        }
    }

    public class EmailService : IIdentityMessageService
    {

        //https://developers.google.com/gmail/imap/imap-smtp
        public Task SendAsync(IdentityMessage message)
        {
            //smtp-mail.outlook.com 
            Common.SendMail(ConfigurationManager.AppSettings["SMTP_SERVER"], int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]), ConfigurationManager.AppSettings["MailPwd"], ConfigurationManager.AppSettings["MailFrom"], message.Destination, message.Subject, message.Body);
            //Common.SendMail("smtp.gmail.com", 587, ConfigurationManager.AppSettings["MailPwd"], ConfigurationManager.AppSettings["MailFrom"], message.Destination, message.Subject, message.Body);
            return Task.FromResult(0);
        }
    }



    public class SignInManager : SignInManager<User, string>
    {
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((UserManager)UserManager);
        }

        public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<UserManager>(), context.Authentication);
        }

    }

}