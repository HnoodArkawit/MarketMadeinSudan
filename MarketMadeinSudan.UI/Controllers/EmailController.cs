using MarketMadeinSudan.Domain;
using Microsoft.AspNetCore.Mvc;
using QuickMailer;
using MailMessage = MarketMadeinSudan.Domin.MailMessage;

namespace MarketMadeinSudan.UI.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(MailMessage mailMessage)
        {
            try
            {
                string mgs = "Email send failed.";
                Email email = new Email();
               bool isSend= email.SendEmail(mailMessage.To, Credential.Email, Credential.Password, mailMessage.Subject,
                   mailMessage.Body);
                if (isSend)
                {
                    mgs = "Email has been .";
                }
                ViewBag.Mge = mgs;
                TempData["success"] = "تم ارسال البريد بنجاح .. شكرا لتواصلك معنا";

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<string>GetValidMail(List<string>mails)
        {
            List<string>validMails=new List<string>();
            Email email = new Email();
            if(mails==null)
            {
                return validMails;
            }
            if (mails.Any())
            {

                foreach (var mail in mails)
                {
                    bool isValid = email.IsValidEmail(mail);
                    if (isValid)
                    {
                        validMails.Add(mail);

                    }
                }
            }

            return validMails;
        }
    }
}
