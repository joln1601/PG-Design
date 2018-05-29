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
        public ContactVM GetContactInfos(ContactVM cvm)
        {
            var model = _DbOperation.ContactInfo.FirstOrDefault();

            cvm.Id = model.Id;
            cvm.Fname = model.Fname;
            cvm.LName = model.LName;
            cvm.Biography = model.Biography;
            cvm.Email = model.Email;
            cvm.ContactUs = model.ContactUs;
            cvm.Phone = model.Phone;
            cvm.Picture_Url = model.Picture_Url;

            return cvm;
        }

        #endregion

        #region Admin

        public void SetAboutText(StartUpViewModel sv)
        {
            var text = _DbOperation.Siteinformation.Single(t => t.Id == sv.Id);

            text.Content = sv.AboutText;


            _DbOperation.SaveChanges();
        }
        public void SetContactInfo(ContactVM ci)
        {
            var contactinfo = _DbOperation.ContactInfo.FirstOrDefault();

            contactinfo.Fname = ci.Fname;
            contactinfo.LName = ci.LName;
            contactinfo.Phone = ci.Phone;
            contactinfo.Email = ci.Email;
            contactinfo.Biography = ci.Biography;
            contactinfo.Picture_Url = ci.Picture_Url;
            contactinfo.ContactUs = ci.ContactUs;

            _DbOperation.SaveChanges();
        }

        #endregion

        #region Accounts
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
        public ApplicationUser GetSpeifikUserForDelete(string id)
        {
            var user = _DbOperation.Users.Where(x => x.Id == id).FirstOrDefault();

            return user;
        }
        public void DeleteUser(string id)
        {
           var user = _DbOperation.Users.Where(x => x.Id == id).FirstOrDefault();

            _DbOperation.Users.Remove(user);
            _DbOperation.SaveChanges();
        }
        public void EditUser(ApplicationUser user)
        {
            var u = _DbOperation.Users.Single(t => t.Id == user.Id);

            u.Id = user.Id;
            u.UserName = user.UserName;
            u.Email = user.Email;

            _DbOperation.SaveChanges();
        }

        #endregion

        #region Webshop
            public IEnumerable<Webshop> GetWebshops()
        {
            var list = _DbOperation.Webshop.ToList();

            return list;
        }

        public void CreateWebshopItem(Webshop ws, string url)
        {
            ws.Picture_Url = url;
            _DbOperation.Webshop.Add(ws);
            _DbOperation.SaveChanges();
        }
        public Webshop GetSpecificWebshop(int id)
        {
            var item = _DbOperation.Webshop.Where(x => x.Id == id).Single();

            return item;
        }
        public WebshopVM GetSpecificWebshopNew(int id)
        {
            var item = _DbOperation.Webshop.Where(x => x.Id == id).Single();

            var vm = new WebshopVM
            {
                Id = item.Id,
                Description = item.Description,
                Picture_Url = item.Picture_Url,
                Price = item.Price,
                Name = item.Name
            };

            return vm;
        }
        public Webshop GetImage(Webshop ws)
        {
            var image = _DbOperation.Webshop.Single(t => t.Id == ws.Id);
            ws.Picture_Url = image.Picture_Url;


            return (ws);

        }
        public void EditWebshopItem(Webshop ws)
        {
            var webshop = _DbOperation.Webshop.Single(t => t.Id == ws.Id);
           

            webshop.Description = ws.Description;
            webshop.Name = ws.Name;
            webshop.Picture_Url = ws.Picture_Url;
            webshop.Price = ws.Price;

            _DbOperation.SaveChanges();
        }
        public void DeleteWebshopItem(Webshop ws)
        {
            var item = _DbOperation.Webshop.Where(x => x.Id == ws.Id).FirstOrDefault();

            _DbOperation.Webshop.Remove(item);
            _DbOperation.SaveChanges();
        }
        #endregion

        #region Images
        
        //Metod för att synka carouselbilderna till databasen
        public void SaveCarouselpics(List<GalleryViewModel> BlobList)
        {
            List<Carousel> list = new List<Carousel>();

            foreach (var item in BlobList)
            {
               var c = new Carousel { Uri = item.URIName };

                list.Add(c);
            }

            foreach (var pic in list)
            {
                _DbOperation.Carousels.Add(pic);
                _DbOperation.SaveChanges();
            }
        }

        public List<GalleryViewModel> GetCarouselPics()
        {
            var list = new List<GalleryViewModel>();

            var pics = _DbOperation.Carousels.ToList();

            foreach (var item in pics)
            {
                list.Add(new GalleryViewModel { URIName = item.Uri, Id = item.Id });
            }

            return list;
        }

        public void SetNewCarouselPics(string uri, int id)
        {
            var pic = _DbOperation.Carousels.Where(x => x.Id == id).FirstOrDefault();
            pic.Uri = uri;

            _DbOperation.SaveChanges();
        }

        #endregion
    }
}