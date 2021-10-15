using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgricultureManagementSystem.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "產品編號")]
        public string ProductId { get; set; }
        [Required]
        [Display(Name = "品種")]
        public string ProductName { get; set; }
    }
}