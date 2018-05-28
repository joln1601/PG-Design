using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pgDesign.Models;

namespace pgDesign.ViewModels
{
    public class ContactVM
    {
        public IEnumerable<ContactInfo> Users { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string Picture_Url { get; set; }
        public string Biography { get; set; }
        public string ContactUs { get; set; }
        public string ContainerName { get; set; }
    }
}