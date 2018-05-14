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
        public int Picture_Id { get; set; }
        [ForeignKey("Picture_Id")]
        public Picture Picture { get; set; }
        public IEnumerable<Webshop> List { get; set; }
    }
}