using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pgDesign.ViewModels
{
    public class GalleryViewModel
    {
        public List<GalleryViewModel> BlobList { get; set; }
        public string ContainerName { get; set; }
        public string PictureName { get; set; }
        public string URIName { get; set; }
        public int Id { get; set; }
    }
}