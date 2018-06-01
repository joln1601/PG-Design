using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pgDesign.dbEngine;
using pgDesign.ViewModels;
using pgDesign.Models;
using System.Threading.Tasks;

namespace pgDesign.Controllers
{
    public class AdminController : Controller
    {
        #region Objects
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
        #endregion

        #region Index
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

                vm.gvm.BlobList = db.GetCarouselPics();

                return View(vm);
            }
        }
        #endregion

        #region Gallery
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
        #endregion

        #region Contact
        public ActionResult ContactAdmin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Cvm.Users = db.GetUsers();
                var model = db.GetContactInfos(Cvm);

                return View(model);
            }
        }
        [HttpPost]
        public async Task<ActionResult> SetContactAdmin(ContactVM ci, HttpPostedFileBase file)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    if (Request.Files != null && Request.Files.Count > 0)
                    {
                        file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                        }
                    }
                    var imageUrl = await AB.UploadBlobtest(file, "profile");
                    ci.Picture_Url = imageUrl;

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
        #endregion

        #region Homesite
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
        #endregion

        #region Accounts
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
                TempData["MessageEdit"] = "<br /> <br /> Kontot har nu blivit uppdaterat";
                return View(user);
            }
        }
        [ActionName("EditUser")]
        public ActionResult Edit(ApplicationUser user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db.EditUser(user);
                return RedirectToAction("GetListOfAccounts");
                
            }
        }
        public ActionResult DeleteUser(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var list = db.GetAllUsers();
                if (list.Count() > 1)
                {
                    var value = db.GetSpeifikUser(id);
                    db.DeleteUser(value.Id);
                }
                TempData["MessageRemove"] = "<br /> <br /> Kontot har nu blivit borttaget";
                return RedirectToAction("GetListOfAccounts");
            }
        
        }
        #endregion

        #region Webshop
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
        public async Task<ActionResult> CreateWebshopItem(Webshop ws, HttpPostedFileBase file)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                    }
                }
                var imageUrl = await AB.UploadBlobtest(file, "webshop");

                db.CreateWebshopItem(ws, imageUrl.ToString());

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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> EditWebshopItem(Webshop ws, HttpPostedFileBase file)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                    }
                }
                if(file.FileName == "")
                {
                    db.GetImage(ws);
                }
                else
                {
                ws.Picture_Url = await AB.UploadBlobtest(file, "webshop");
                    

                }
                db.EditWebshopItem(ws);

                return RedirectToAction("WebshopAdminList");
            }
           
        }
        public ActionResult _MoreInfo(int id)
        {
            var ws = db.GetSpecificWebshop(id);

            return PartialView(ws);
        }
        #endregion

        #region Images
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadImage(HttpPostedFileBase file, string ContainerName)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                    }
                }

                var imageUrl = await AB.UploadBlobtest(file, ContainerName);

                TempData["LatestImage"] = imageUrl.ToString();
                return RedirectToAction("Index", "Gallery", new { id = ContainerName });
            }
        }
        public ActionResult DeleteWebshopItem(int id)
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
        [HttpPost]
        [ActionName("DeleteWebshop")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWebshopItem(Webshop ws)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db.DeleteWebshopItem(ws);
                return RedirectToAction("WebshopAdminList");

            }
        }
        #endregion

        #region caurousell
        [HttpPost]
        public async Task<ActionResult> ChangeCarPics(HttpPostedFileBase file, int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                    }
                }


                var imageUrl = await AB.UploadBlobtest(file, "carouselpictures");

                db.SetNewCarouselPics(imageUrl.ToString(), id);

                return RedirectToAction("Index", "Admin");
            }
        }
        #endregion
        #region statistics
        public ActionResult Statistics()
        {
            return View();
        }
        #endregion
    }
}