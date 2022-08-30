using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class ContactController : Controller
    {
        ContactManager CM = new ContactManager(new EfContactDal());
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Home(Contact contact)
        {
            CM.Add(contact);
            contact.ContactDateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            return RedirectToAction("Home","Blog");
        }
    }
}
