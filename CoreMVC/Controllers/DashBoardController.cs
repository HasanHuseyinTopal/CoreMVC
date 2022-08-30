using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class DashBoardController : Controller
    {
        BlogManager BM = new BlogManager(new EfBlogDal());
        public IActionResult Home()
        {
            ViewBag.v3 = BM.GetLastBlogsAt7Days().Count();

            ViewBag.v2 = BM.GetBlogListByWriterID(1).Count();

            ViewBag.v1 = BM.GetAll().Count();

            return View();
        }
    }
}
