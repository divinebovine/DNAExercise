using System;
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
        private readonly string uploadFolder = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

        [HttpGet]
        public ActionResult Index(string fileName)
        {
            DNA model = null;
            if (!String.IsNullOrWhiteSpace(fileName))
            {
                string file = Path.Combine(uploadFolder, fileName);
                string text = System.IO.File.ReadAllText(file);
                model = new DNA(text);
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
