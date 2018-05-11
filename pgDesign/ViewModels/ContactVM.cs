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
    }
}