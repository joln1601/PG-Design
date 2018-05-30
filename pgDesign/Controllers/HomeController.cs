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
    public class HomeController : Controller
    {
        private dbOperation db;
        private StartUpViewModel vm;
        private ContactVM Cvm;
        private AzureBlobHelper AB;
        private postedFileModel pfm;
        public HomeController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
            Cvm = new ContactVM();
            AB = new AzureBlobHelper();
            pfm = new postedFileModel();
        }
        
        public ActionResult Index()
        {
            //Bilder för karusell
            //vm.CarouselPics = db.GetCarouselPic();
            
            // Om oss text
            var SiteInfoAboutText = db.SiteinfoText(1);
            vm.AboutText = SiteInfoAboutText.Content;
            vm.Id = SiteInfoAboutText.Id;     
            // Avikande öppettider
            var SiteInfoOpen = db.SiteinfoText(2);
            vm.OpenTimes = SiteInfoOpen.Content;

            //string ContainerName = "carouselpictures";
            //vm.gvm = AB.GetListOfData(pfm, ContainerName);
            //db.SaveCarouselpics(vm.gvm.BlobList);

            vm.gvm.BlobList = db.GetCarouselPics();

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var model = db.GetContactInfos(Cvm);

            return View(model);
        }
        public ActionResult FindUs()
        {
            return View();
        }
    }
}