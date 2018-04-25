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
    }
}