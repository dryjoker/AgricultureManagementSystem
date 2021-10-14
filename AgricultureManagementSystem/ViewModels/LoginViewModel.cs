using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name ="電子信箱")]
        [EmailAddress]
        public string Email { get; set; }
        
        
        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="記住我?")]
        public bool RememberMe { get; set; }
    }
}