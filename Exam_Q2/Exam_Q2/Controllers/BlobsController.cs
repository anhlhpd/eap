using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Exam_Q2.Controllers
{
    public class BlobsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //private CloudBlobContainer GetCloudBlobContainer()
        //{
        //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        //            CloudConfigurationManager.GetSetting("<storageaccountname>_AzureStorageConnectionString"));
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        //    CloudBlobContainer container = blobClient.GetContainerReference("test-blob-container");
        //    return container;
        //}
    }
}