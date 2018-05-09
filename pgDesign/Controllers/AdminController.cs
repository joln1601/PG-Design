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
    public class AdminController : Controller
    {
        private dbOperation db;
        private StartUpViewModel vm;
        private ContactVM Cvm;
        private AzureBlobHelper AB;
        private postedFileModel pfm;
        public AdminController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
            Cvm = new ContactVM();
            AB = new AzureBlobHelper();
            pfm = new postedFileModel();
    }
        // GET: Admin
        public ActionResult Index()
        {
            //Bilder för karusell
            vm.CarouselPics = db.GetCarouselPic();

            // Om oss text
            var SiteInfoAboutText = db.SiteinfoText(1);
            vm.AboutText = SiteInfoAboutText.Content;
            vm.Id = SiteInfoAboutText.Id;

            // Avikande öppettider
            var SiteInfoOpen = db.SiteinfoText(2);
            vm.OpenTimes = SiteInfoOpen.Content;

            string ContainerName = "carouselpictures";

            vm.Bloblist = AB.GetListOfData(pfm, ContainerName);

            return View(vm);
        }
        public ActionResult GalleryAdmin()
        {
            return View();
        }
        public ActionResult ContactAdmin()
        {
            Cvm.Users = db.GetUsers();

         

            return View(Cvm);
            
        }
        [HttpPost]
        public ActionResult SetContactAdmin(ContactInfo ci)
        {
            try
            {
                
            db.SetContactInfo(ci);
            TempData["Message"] = "<br />Uppgifterna har nu blivit sparade.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "<br /> Det har uppstått ett fel <br /> <br />" + ex;
               
            }
            return RedirectToAction("ContactAdmin");
        }

        [HttpPost]
        public ActionResult AboutText(StartUpViewModel sv)
        {
            db.SetAboutText(sv);
            return RedirectToAction("Index");
        }

    }
}