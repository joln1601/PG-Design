using pgDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pgDesign.ViewModels;
using System.Data.Entity;

namespace pgDesign.dbEngine
{
    public class dbOperation
    {
        ApplicationDbContext _DbOperation;
        public dbOperation()
        {
            _DbOperation = new ApplicationDbContext();
        }


        #region Siteinformation
        public Siteinformation SiteinfoText(int id)
        {

            var text = _DbOperation.Siteinformation.Where(c => c.Id == id).Single();
            return text;
        }

        #endregion

        #region ContactPage
        public IEnumerable<ContactInfo> GetUsers()
        {
            var users = _DbOperation.ContactInfo.ToList();

            return users;
        }

        public Picture GetProfilePic(int id)
        {
            var pic = _DbOperation.Picture.Where(x => x.Id == id).Single();

            return pic;
        }

        public IEnumerable<PictureAttachment> GetCarouselPic()
        {
            int carouselId = 1;

            var pics = _DbOperation.PictureAttachment.Where(x => x.Gallery.Category.Id == carouselId).ToList();

            foreach (var item in pics)
            {
                GetPicturesToList(item);
            }
            return pics;
        }

        private void GetPicturesToList(PictureAttachment item)
        {
            var pictures = _DbOperation.Picture.Where(x => x.Id == item.Picture_id).ToList();
        }

        #endregion

        #region Admin

        public void SetAboutText(StartUpViewModel sv)
        {
            var text = _DbOperation.Siteinformation.Single(t => t.Id == sv.Id);

            text.Content = sv.AboutText;


            _DbOperation.SaveChanges();
        }
        public void SetContactInfo(ContactInfo ci)
        {
            var contactinfo = _DbOperation.ContactInfo.Single(t => t.Id == ci.Id);

            contactinfo.Fname = ci.Fname;
            contactinfo.LName = ci.LName;
            contactinfo.Phone = ci.Phone;
            contactinfo.Email = ci.Email;
            contactinfo.Biography = ci.Biography;

            _DbOperation.SaveChanges();
        }
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            var list = _DbOperation.Users.ToList();

            return list;
        }
        public ApplicationUser GetSpeifikUser(string id)
        {
            var user = _DbOperation.Users.Where(x => x.Id == id).Single();

            return user;
        }
        #endregion
        #region Webshop
        public IEnumerable<Webshop> GetWebshops()
        {
            var List = _DbOperation.Picture.ToList();

            var list = _DbOperation.Webshop.ToList();

            return list;
        }

        public void CreateWebshopItem(Webshop ws)
        {
            _DbOperation.Webshop.Add(ws);
            _DbOperation.SaveChanges();
        }
        public Webshop GetSpecificWebshop(int id)
        {
            var item = _DbOperation.Webshop.Where(x => x.Id == id).Single();

            return item;
        }
        public void EditWebshopItem(Webshop ws)
        {
            var webshop = _DbOperation.Webshop.Single(t => t.Id == ws.Id);

            webshop.Description = ws.Description;
            webshop.Name = ws.Name;
            webshop.Picture_Id = ws.Picture_Id;
            webshop.Price = ws.Price;

            _DbOperation.SaveChanges();
        }
        #endregion

        public void SaveImageToDb(postedFileModel pf)
        {
            Picture p = new Picture() { ImageAddress = pf.filePath, Name = pf.filename };

            _DbOperation.Picture.Add(p);
            _DbOperation.SaveChanges();
        }
    }

}