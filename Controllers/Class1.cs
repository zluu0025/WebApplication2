using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication2.Controllers;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult File_Save()
        {
            return View();
        }


        [HttpPost]
        public ActionResult File_Save(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/File Saved"), filename);
                    file.SaveAs(filepath);


                }
                ViewBag.Message = "Upload file Saved Successfully in the folder";
                return View();
            }
            catch
            {

                ViewBag.Message = "Upload file Saved Successfully in the folder";
                return View();
            }

        }

    }
}