using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pgDesign.dbEngine;
using pgDesign.ViewModels;

namespace pgDesign.Controllers
{
    public class HomeController : Controller
    {
        private dbOperation db;
        private StartUpViewModel vm;
        public HomeController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
        }
        
        public ActionResult Index()
        {
            // Om oss text
           var SiteInfoAboutText = db.SiteinfoText(1);
            vm.AboutText = SiteInfoAboutText.Content;
            // Avikande öppettider
            var SiteInfoOpen = db.SiteinfoText(2);
            vm.OpenTimes = SiteInfoOpen.Content;
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FindUs()
        {
            

            return View();
        }
    }
}