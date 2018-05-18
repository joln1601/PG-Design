using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace pgDesign.Models
{
    public class Webshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture_Url { get; set; }
        public IEnumerable<Webshop> List { get; set; }
    }
}