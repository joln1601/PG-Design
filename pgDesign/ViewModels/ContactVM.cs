using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pgDesign.Models;

namespace pgDesign.ViewModels
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public IEnumerable<ContactInfo> Users { get; set; }
    }
}