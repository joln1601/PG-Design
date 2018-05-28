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
        public string Picture_Url { get; set; }
        public string Biography { get; set; }
        public string ContactUs { get; set; }
    }
}