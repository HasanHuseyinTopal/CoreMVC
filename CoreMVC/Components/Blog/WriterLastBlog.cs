using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager BM = new BlogManager(new EfBlogDal());
       
        public IViewComponentResult Invoke(int ID)
        {
            var result= BM.GetBlogListByWriterID(ID);
            return View(result);
        }
    }
}
