using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pgDesign.dbEngine;
using pgDesign.ViewModels;
using pgDesign.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace pgDesign.Controllers
{
    public class HomeController : Controller
    {
        private dbOperation db;
        private StartUpViewModel vm;
        private ContactVM Cvm;
        private AzureBlobHelper AB;
        private postedFileModel pfm;
        private EmailService ES;
        public HomeController()
        {
            db = new dbOperation();
            vm = new StartUpViewModel();
            Cvm = new ContactVM();
            AB = new AzureBlobHelper();
            pfm = new postedFileModel();
            ES = new EmailService();
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
            ViewBag.OpenTimes = SiteInfoOpen.Content;

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

        [HttpGet]
        public string Opentimes()
        {
            var SiteInfoOpen = db.SiteinfoText(2);
            string ret = SiteInfoOpen.Content;

            return ret;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendMail(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                if (model.Mail.Subject != null || model.Mail.Content != null || model.Mail.Email != null)
                {
                    IdentityMessage msg = new IdentityMessage
                    {
                        Subject = model.Mail.Subject,
                        Body = model.Mail.Content,
                        Destination = model.Mail.Receiver
                    };

                    await ES.SendAsync(msg);
                    return RedirectToAction("Contact", "Home");
                }
                else
                {

                }

            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}