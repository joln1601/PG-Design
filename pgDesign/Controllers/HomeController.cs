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
        private IndexViewModel vm;
        public HomeController()
        {
            db = new dbOperation();
            vm = new IndexViewModel();
        }
        
        public ActionResult Index()
        {

           var Siteinfo = db.AboutText();
            vm.AboutText = Siteinfo.Content;
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