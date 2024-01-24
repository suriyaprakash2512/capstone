using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppBlogMVC.Models
{
    public class Login
    {
        [Key]
        [Required]
        [Display(Name = "EmailId")]
        public string EmailId { get; set; }

        [Required]
        [Display(Name = "User Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}