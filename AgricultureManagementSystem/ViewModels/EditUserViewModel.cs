using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "信箱")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "外場")]
        public string Region { get; set; }

    }
}