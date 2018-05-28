using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pgDesign.Models;

namespace pgDesign.ViewModels
{
    public class StartUpViewModel
    {
        public int Id { get; set; }
        public string AboutText { get; set; }
        public string OpenTimes { get; set; }
        public List<string> Bloblist { get; set; }
        
        public GalleryViewModel gvm { get; set; }
    }
}