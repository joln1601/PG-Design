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

        public ActionResult Index(string id)
        {
            if(id == null)
            {
                id = "bildekor";
                gvm = AB.GetListOfData(pfm, id);

                return View(gvm);
            }
            else
            {
                gvm = AB.GetListOfData(pfm, id);
                return View(gvm);
            }

      
            
        }
       
        public ActionResult DeleteImage(string url, string cn, string pn)
        {
            AB.DeleteFile(cn, pn);

            return RedirectToAction("Index");
        }
       
    }
}