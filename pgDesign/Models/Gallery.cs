using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pgDesign.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}