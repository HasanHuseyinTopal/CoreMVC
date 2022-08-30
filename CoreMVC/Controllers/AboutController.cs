using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class AboutController : Controller
    {
        AboutManager AM = new AboutManager(new EfAboutDal());
        public IActionResult Home()
        {
           
            return View(AM.GetAll());
        }
        public PartialViewResult AboutSocialMedia()
        {
            return PartialView();
        }
    }
}
