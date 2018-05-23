﻿using pgDesign.Models;
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
        public void EditWebshopItem(Webshop ws, string url)
        {
            var webshop = _DbOperation.Webshop.Single(t => t.Id == ws.Id);
            ws.Picture_Url = url;

            webshop.Description = ws.Description;
            webshop.Name = ws.Name;
            webshop.Picture_Url = ws.Picture_Url;
            webshop.Price = ws.Price;

            _DbOperation.SaveChanges();
        }
        public void DeleteWebshopItem(int id)
        {
            var item = _DbOperation.Webshop.Where(x => x.Id == id).FirstOrDefault();

            _DbOperation.Webshop.Remove(item);
            _DbOperation.SaveChanges();
        }
        #endregion

        #region Images
        public void SaveImageToDb(string uri)
        {
            Picture p = new Picture() { ImageAddress = uri };

            _DbOperation.Picture.Add(p);
            _DbOperation.SaveChanges();
        }
        #endregion
    }
}