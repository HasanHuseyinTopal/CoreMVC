using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.Blog
{
    public class BlogListDashBoard : ViewComponent
    {
        BlogManager BM = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke(int id)
        {
            var result= BM.GetListWithCategoryByWriterID(id);
            return View(result);
        }
    }
}
