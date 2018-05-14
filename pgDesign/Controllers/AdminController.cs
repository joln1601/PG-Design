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
        private Webshop ws;
        public AdminController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
            Cvm = new ContactVM();
            AB = new AzureBlobHelper();
            pfm = new postedFileModel();
            ws = new Webshop();

    }
        // GET: Admin
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var SiteInfoAboutText = db.SiteinfoText(1);
                vm.AboutText = SiteInfoAboutText.Content;
                vm.Id = SiteInfoAboutText.Id;

                var SiteInfoOpen = db.SiteinfoText(2);
                vm.OpenTimes = SiteInfoOpen.Content;

                string ContainerName = "carouselpictures";

                vm.Bloblist = AB.GetListOfData(pfm, ContainerName);

                return View(vm);
            }
        }
        public ActionResult GalleryAdmin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ContactAdmin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Cvm.Users = db.GetUsers();
                return View(Cvm);
            }
        }
        [HttpPost]
        public ActionResult SetContactAdmin(ContactInfo ci)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
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
        }

        [HttpPost]
        public ActionResult AboutText(StartUpViewModel sv)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db.SetAboutText(sv);
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetListOfAccounts()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var list = db.GetAllUsers();
                return View(list);
            }
        }
        public ActionResult Edit(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var user = db.GetSpeifikUser(id);
                return View(user);
            }
        }
        public ActionResult WebshopAdminList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
               var list = db.GetWebshops();
                return View(list);
            }
        }
        public ActionResult CreateWebshopItem()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWebshopItem(Webshop ws)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db.CreateWebshopItem(ws);
                return RedirectToAction("WebshopAdminList");
            }
        }
        public ActionResult EditWebshopItem(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var ws = db.GetSpecificWebshop(id);


                return View(ws);
            }
        }
        [ActionName("EditItem")]
        public ActionResult EditWebshopItem(Webshop ws)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db.EditWebshopItem(ws);

                return RedirectToAction("WebshopAdminList");
            }
        }
    }
}