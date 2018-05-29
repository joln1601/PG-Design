using pgDesign.dbEngine;
using pgDesign.Models;
using pgDesign.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pgDesign.Controllers
{
    public class WebshopController : Controller
    {
        private dbOperation db;
        private WebshopVM ws;
        private StartUpViewModel vm;
        private AzureBlobHelper AB;
        private postedFileModel pfm;
        private ContactVM cvm;
        public WebshopController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
            AB = new AzureBlobHelper();
            pfm = new postedFileModel();
            ws = new WebshopVM();
            cvm = new ContactVM();
        }
        // GET: Webshop
        public ActionResult Index()
        {
            ws.WebshopItems = db.GetWebshops();

            return View(ws);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WebshopView(int id)
        {
            var item = db.GetSpecificWebshopNew(id);
            item.Cvm = db.GetContactInfos(cvm);

            return View(item);
        }
    }
}
