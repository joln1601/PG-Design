using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace pgDesign.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string UserId { get; set; }
        public int Picture_Id { get; set; }
        public string Biography { get; set; }
        public string ContactUs { get; set; }

        [ForeignKey("Picture_Id")]
        public Picture Picture { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}