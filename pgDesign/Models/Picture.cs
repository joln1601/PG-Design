using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pgDesign.Models
{
    public class Picture
    {
        public int Id  { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}