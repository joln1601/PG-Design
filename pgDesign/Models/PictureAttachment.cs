using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace pgDesign.Models
{
    public class PictureAttachment
    {
        public int Id { get; set; }
        public int Picture_id { get; set; }
        public int Gallery_id { get; set; }

        [ForeignKey("Picture_id")]
        public Picture Picture { get; set; }

        [ForeignKey("Gallery_id")]
        public Gallery Gallery { get; set; }
    }
}