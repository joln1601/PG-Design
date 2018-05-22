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
using pgDesign.dbEngine;
using pgDesign.ViewModels;
using System.Threading.Tasks;

namespace pgDesign.dbEngine
{
    public class AzureBlobHelper
    {

        #region Constructorer
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

        #endregion
        //public AzureBlobHelper()
        //{
        //    _blobcontainer.CreateIfNotExists();
        //}
        public void SaveDataToAzureBlob(postedFileModel filemodel, string ContainerName)
        {
            //CloudBlobContainer _blobcontainer = new CloudBlobContainer(null);
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ContainerName);

            HttpWebRequest _requestPage = (HttpWebRequest)WebRequest.Create(filemodel.filePath);
            HttpWebResponse _responseRequest = (HttpWebResponse)_requestPage.GetResponse();
            CloudBlockBlob _blockblob = container.GetBlockBlobReference(filemodel.filename); //Createing a Blob  

            // Create or overwrite the blob with contents from a local file.  

            _blockblob.UploadFromStream(_responseRequest.GetResponseStream());

            
        }

        #region Hämtning av blobbar
        public List<string> GetListOfData(postedFileModel filemodel, string containerName)
        {
            
            List<string> list = new List<string>();
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));
            //Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Retrieve reference to a previously created container.
           CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            //Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    list.Add(blob.Uri.ToString());

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;
                    list.Add(pageBlob.Uri.ToString());
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;
                    list.Add(directory.Uri.ToString());
                }
            }
            return list;

            #endregion

        }
        
        public async Task<string> UploadBlobtest(HttpPostedFileBase imageToUpload)
        {
            string imageFullPath = null;
            if (imageToUpload == null || imageToUpload.ContentLength == 0)
            {
                return null;
            }
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                 CloudConfigurationManager.GetSetting("StorageConnectionString"));
                //Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                //Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference("webshop");

                if (await container.CreateIfNotExistsAsync())
                {
                    await container.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.InputStream);

                imageFullPath = cloudBlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return imageFullPath;
        }
    }

}