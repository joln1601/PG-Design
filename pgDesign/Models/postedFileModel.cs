using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager  
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount  
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types  
using Microsoft.Azure; // Namespace for CloudConfigurationManager

namespace pgDesign.Models
{
    public class postedFileModel
    {
        public string filePath { get; set; }
        public string filename { get; set; }
    }
}