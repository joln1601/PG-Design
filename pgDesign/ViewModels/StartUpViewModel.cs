using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pgDesign.Models;

namespace pgDesign.ViewModels
{
    public class StartUpViewModel
    {
        public string AboutText { get; set; }
        public string OpenTimes { get; set; }
        public IEnumerable<PictureAttachment> CarouselPics { get; set; }
    }
}