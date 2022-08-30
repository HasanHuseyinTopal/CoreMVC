using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager BM = new BlogManager(new EfBlogDal());

        public IViewComponentResult Invoke()
        {
            var values=BM.GetLeast3Blog();
            return View(values);
        }
    }
}
