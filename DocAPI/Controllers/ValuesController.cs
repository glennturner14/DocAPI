using DocAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {

            //string tempFolder = System.Web.Hosting.HostingEnvironment.MapPath("~/"); //"C:\\CodeGames\\TempDocuments";
            //DocumentController docController = new DocumentController();
            //docController.SelectStorage(DocumentStorage.Dropbox);
            //docController.SetStoragePath("/");
            //docController.SetFilePath(tempFolder);
            //string fileList = docController.GetFiles();
            //docController.Download("Get Started with Dropbox.pdf");
            //docController.SelectStorage(DocumentStorage.GoogleDrive);
            //docController.Upload("Get Started with Dropbox.pdf");
            string rootPath = string.Empty; 
            try
            {
                rootPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                string tempFolder = rootPath;// Server.MapPath("~/") + "TempDocuments";
                DocumentController docController = new DocumentController();
                docController.SelectStorage(DocumentStorage.Dropbox);
                docController.SetStoragePath("/");
                docController.SetFilePath(tempFolder);
                string fileList = docController.GetFiles();
                docController.Download("Get Started with Dropbox.pdf");
                docController.SelectStorage(DocumentStorage.GoogleDrive);
                docController.Upload("Get Started with Dropbox.pdf");
            }
            catch (Exception ex)
            {
                return new string[] { ex.ToString(), rootPath };
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post(Document document)
        {
            try
            {
                var rootPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                string tempFolder = rootPath;// Server.MapPath("~/") + "TempDocuments";
                DocumentController docController = new DocumentController();
                docController.SelectStorage(DocumentStorage.Dropbox);
                docController.SetStoragePath("/");
                docController.SetFilePath(tempFolder);
                string fileList = docController.GetFiles();
                docController.Download("Get Started with Dropbox.pdf");
                docController.SelectStorage(DocumentStorage.GoogleDrive);
                docController.Upload("Get Started with Dropbox.pdf");
            } catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(ex.ToString()) };
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
