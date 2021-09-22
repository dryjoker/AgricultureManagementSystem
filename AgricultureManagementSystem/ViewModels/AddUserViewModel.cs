using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "未填寫電子郵件")]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required(ErrorMessage = "未填寫使用者帳號")]
        [Display(Name = "使用者帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "未填寫密碼")]
        [StringLength(50, ErrorMessage = "{0}密碼長度至少要有{2}個字元長。", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="確認密碼")]
        [Compare("Password",ErrorMessage ="輸入確認密碼不相同。")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "未選擇外場")]
        [Display(Name ="外場")]
        public string Region { get; set; }
    }
}