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
        public Siteinformation AboutText()
        {
            var text = _DbOperation.Siteinformation.Where(c => c.Id == 1).Single();

            return text;
        }
        #endregion

        #region ContactPage
        public IEnumerable<ContactInfo> GetUsers()
        {
            var users = _DbOperation.ContactInfo.ToList();

            return users;
            //foreach (var u in users)
            //{
            //    Cvm.Fname = u.Fname;
            //    Cvm.Lname = u.LName;
            //    Cvm.Phone = u.Phone;
            //    Cvm.Email = u.Email;
            //}

        }
        #endregion
    }
}