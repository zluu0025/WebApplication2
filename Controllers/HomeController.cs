using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;
using WebApplication2.E_mail_Sending;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new Vmodel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(Vmodel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail;
                    String subject;
                    String contents;
                    String cc;
                    String fp;
                    model.ToEmail = Sanitizer.GetSafeHtmlFragment(model.ToEmail);
                    model.Subject = Sanitizer.GetSafeHtmlFragment(model.Subject);
                    model.Contents = Sanitizer.GetSafeHtmlFragment(model.Contents);
                    model.Cc = Sanitizer.GetSafeHtmlFragment(model.Cc);

                    EmailSender es = new EmailSender();
                    toEmail = model.ToEmail;
                    subject = model.Subject;
                    contents = model.Contents;
                    cc = model.Cc;
                    fp = model.FP;

                    if (toEmail.Contains(";") && cc == null)
                    {
                        string[] tocheckemail = toEmail.Split(';');
                        foreach (string newemail in tocheckemail)
                        {
                            _ = es.SendAsync(newemail, subject, contents, fp, cc);
                        }
                    }
                    else
                    {
                        _ = es.SendAsync(toEmail, subject, contents, fp, cc);
                    }
                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new Vmodel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}