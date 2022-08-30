using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class NewsLatterController : Controller
    {
        NewsLatterManager NLM = new NewsLatterManager(new EfNewsLatterDal());
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLatter newsLatter)
        {
            var register= NLM.GetAll();
            foreach (var item in register)
            {
                if (item.Mail==newsLatter.Mail)
                {
                    break;
                }
                else if(register.Count==item.MailID)
                {
                    newsLatter.MailStatus = true;
                    NLM.Add(newsLatter);
                }
            }
            return RedirectToAction("Home", "Blog");
        }
    }
}
