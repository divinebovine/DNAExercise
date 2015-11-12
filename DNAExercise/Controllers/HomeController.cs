using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DNAExercise.Models;

namespace DNAExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly string uploadFolder = 
            Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),
                         ConfigurationManager.AppSettings["UploadFolder"]);

        [HttpGet]
        public ActionResult Index(string fileName)
        {
            DNA model = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(fileName))
                {
                    string file = Path.Combine(uploadFolder, fileName);
                    string text = System.IO.File.ReadAllText(file);
                    model = new DNA(text);
                }
            }
            catch (FileNotFoundException e)
            {
                model = new DNA(feedback:string.Format("Unable to find {0}.", fileName));
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null)
            {
                UploadFile(file);
                return RedirectToAction("Index", new { filename = file.FileName });
            }
            return RedirectToAction("Index");
        }

        private void UploadFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = file.FileName;
                var path = Path.Combine(uploadFolder, fileName);
                file.SaveAs(path);
            }
        }
    }
}
