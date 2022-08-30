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
    public class CommentController : Controller
    {
        CommentManager CM = new CommentManager(new EfCommentDal());
        public PartialViewResult CommentAddPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult CommentAddPartial(Comment comment)
        {
           
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 2;
            CM.Add(comment);
            return RedirectToAction("Home","Blog");
        }
    }
}
