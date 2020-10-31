using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hemsida.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string from, string password, string subject, string mess)
        {
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress("marcus_batan@hotmail.com"));
                message.From = new MailAddress(from);
                message.Subject = subject;
                message.Body = string.Format(mess, from);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = from,
                        Password = password
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent", "Contact");
                }
            }
            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}