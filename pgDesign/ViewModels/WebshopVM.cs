using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pgDesign.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pgDesign.ViewModels
{
    public class WebshopVM
    {
        public IEnumerable<Webshop> WebshopItems { get; set; }
        public postedFileModel Pf { get; set; }
        public Webshop Ws { get; set; }
        public HttpPostedFileBase File { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture_Url { get; set; }
    }
}