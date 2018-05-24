using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pgDesign.Models
{
    public class Webshop
    {
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Endast siffror tillåtna")]
        [Display(Name = "Pris")]
        public double Price { get; set; }
        [Display(Name = "Bild")]
        public string Picture_Url { get; set; }
        public IEnumerable<Webshop> List { get; set; }
    }
}