using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pgDesign.ViewModels
{
    public class MailVM
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        public string Receiver { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public MailVM()
        {
            Receiver = "Jonte.9744@gmail.com";
        }
    }
}