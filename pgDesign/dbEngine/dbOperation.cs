using pgDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}