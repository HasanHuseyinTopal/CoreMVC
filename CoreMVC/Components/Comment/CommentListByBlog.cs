using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager CM = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int ID)
        {
            var values = CM.GetAllByBlogID(ID);
            return View(values);
        }
    }
}
