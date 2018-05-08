using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pgDesign.ViewModels
{
    public class GalleryViewModel
    {
        public List<string> LackeringBlobList { get; set; }
        public List<string> PlatjobBlobList { get; set; }
        public List<string> OmbyggnadBlobList { get; set; }
        public List<string> OvrigtBlobList { get; set; }
    }
}