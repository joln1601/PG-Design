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
            int? idet = Convert.ToInt32(id);
            if(idet == null || idet == 1)
            {
            string bildekor = "bildekor";
            gvm.BlobList = AB.GetListOfData(pfm, bildekor);
                return View(gvm);
            }
            else if (idet == 2)
            {
                string ombyggnadavfordon = "ombyggnadavfordon";
                gvm.BlobList = AB.GetListOfData(pfm, ombyggnadavfordon);
                return View(gvm);
            }
            else if (idet == 3)
            {
                string utstallningarochinredningar = "utstallningarochinredningar";
                gvm.BlobList = AB.GetListOfData(pfm, utstallningarochinredningar);
                return View(gvm);
            }
            else if (idet == 4)
            {
                string skyltar = "skyltar";
                gvm.BlobList = AB.GetListOfData(pfm, skyltar);
                return View(gvm);
            }
            else if (idet == 5)
            {
                string arbetsmiljolosningar = "arbetsmiljolosningar";
                gvm.BlobList = AB.GetListOfData(pfm, arbetsmiljolosningar);
                return View(gvm);
            }
            else if (idet == 6)
            {
                string offentligutsmyckning = "offentligutsmyckning";
                gvm.BlobList = AB.GetListOfData(pfm, offentligutsmyckning);
                return View(gvm);
            }
            else if (idet == 7)
            {
                string legotillverkningochinnovationer = "legotillverkningochinnovationer";
                gvm.BlobList = AB.GetListOfData(pfm, legotillverkningochinnovationer);
                return View(gvm);
            }
            else if (idet == 8)
            {
                string ovrigt = "ovrigt";
                gvm.BlobList = AB.GetListOfData(pfm, ovrigt);
                return View(gvm);
            }

            return View();
            
        }
       
    }
}