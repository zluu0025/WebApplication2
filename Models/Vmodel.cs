using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SendGrid.Helpers.Mail;

namespace WebApplication2.E_mail_Sending
{
    public class Vmodel
    {

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]

        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the contents")]
        public string Contents { get; set; }

        [Display(Name = "Uploaded file and  file extension")]
        public string FP { get; set; }

        [Display(Name = "CC to someon else")]
        [Required(ErrorMessage = "Please CC to us for the assisting or records purpose for better service Thank you.")]
        public string Cc { get; set; }


    }
}