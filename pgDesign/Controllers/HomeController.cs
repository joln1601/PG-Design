﻿using System;
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
        private ContactVM Cvm;
        public HomeController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
            Cvm = new ContactVM();
        }
        
        public ActionResult Index()
        {
            //Bilder för karusell
            vm.CarouselPics = db.GetCarouselPic();
            
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
            Cvm.Users = db.GetUsers();

            foreach (var item in Cvm.Users)
            {
                db.GetProfilePic(item.Picture_Id);
            }

            return View(Cvm);
        }
        public ActionResult FindUs()
        {
            

            return View();
        }
    }
}