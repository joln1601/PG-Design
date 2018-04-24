using pgDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pgDesign.ViewModels;

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

        
        #endregion
    }
}