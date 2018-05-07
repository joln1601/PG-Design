using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pgDesign.dbEngine;
using pgDesign.ViewModels;
using pgDesign.Models;

namespace pgDesign.Controllers
{
    public class GalleryController : Controller
    {
        private AzureBlobHelper AB;
        private GalleryViewModel gvm;
        private postedFileModel pfm;
        // GET: Gallery
        public GalleryController()
        {
            AB = new AzureBlobHelper();
            gvm = new GalleryViewModel();
            pfm = new postedFileModel();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Platjobb()
        {
            return View();
        }
        public ActionResult Lackering()
        {
            string ContainerName = "lackering";

            gvm.LackeringBlobList = AB.GetListOfData(pfm, ContainerName);
            return View(gvm);
        }
    }
}