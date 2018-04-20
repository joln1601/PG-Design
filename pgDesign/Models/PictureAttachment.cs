using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pgDesign.Models
{
    public class PictureAttachment
    {
        public int Id { get; set; }
        public Picture Picture { get; set; }
        public Gallery Gallery { get; set; }
    }
}