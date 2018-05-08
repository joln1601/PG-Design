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
            string platjob = "platjobb";
            gvm.PlatjobBlobList = AB.GetListOfData(pfm, platjob);

            return View(gvm);
        }
        public ActionResult Lackering()
        {
            string lack = "lackering";
            gvm.LackeringBlobList = AB.GetListOfData(pfm, lack);

            return View(gvm);
        }
        public ActionResult Ombyggnad()
        {
            string ombyggnad = "ombyggnad";
            gvm.OmbyggnadBlobList = AB.GetListOfData(pfm, ombyggnad);

            return View(gvm);
        }
        public ActionResult Ovrigt()
        {
            string ovrigt = "ovrigt";
            gvm.OvrigtBlobList = AB.GetListOfData(pfm, ovrigt);

            return View(gvm);
        }
    }
}