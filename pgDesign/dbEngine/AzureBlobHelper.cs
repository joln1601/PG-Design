using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager  
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount  
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types  
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using pgDesign.Models;
using System.IO;
using System.Net;

namespace pgDesign.dbEngine
{
    public class AzureBlobHelper
    {
        CloudStorageAccount storageAAccountConnection
        {
            get
            {
                return CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            }
        } //Getting Blob Connection string  
        CloudBlobClient _blobClient
        {
            get
            {
                return storageAAccountConnection.CreateCloudBlobClient();
            }
        }
        CloudBlobContainer _blobcontainer
        {
            get
            {
                return _blobClient.GetContainerReference("sampl");
            }
        }
        public AzureBlobHelper()
        {
            _blobcontainer.CreateIfNotExists();
        }
        public void SaveDataToAzureBlob(postedFileModel filemodel)
        {
            Stream _streamContent;
            HttpWebRequest _requestPage = (HttpWebRequest)WebRequest.Create(filemodel.filePath);
            HttpWebResponse _responseRequest = (HttpWebResponse)_requestPage.GetResponse();
            CloudBlockBlob _blockblob = _blobcontainer.GetBlockBlobReference(filemodel.filename); //Createing a Blob  
                                                                                                  // Create or overwrite the blob with contents from a local file.  
            _blockblob.UploadFromStream(_responseRequest.GetResponseStream());
        }
        public List<BlobList> GetListOfData(postedFileModel filemodel)
        {
            List<BlobList> _blobList = new List<BlobList>();
            if (filemodel != null)
            {
                CloudBlockBlob _blobpage = (CloudBlockBlob)_blobcontainer.ListBlobs(filemodel.filename, false).FirstOrDefault();
                _blobList.Add(new BlobList()
                {
                    URI = _blobpage.Uri.ToString(),
                    length = _blobpage.Properties.Length
                });
            }
            else
            {
                foreach (IListBlobItem item in _blobcontainer.ListBlobs(null, false))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob _blobpage = (CloudBlockBlob)item;
                        _blobList.Add(new BlobList()
                        {
                            URI = _blobpage.Uri.AbsoluteUri.ToString(),
                            length = _blobpage.Properties.Length
                        });
                    }
                }
            }
            return _blobList;
        }
    }

}