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

    }
}