using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class BlogController : Controller
    {
        BlogManager BM = new BlogManager(new EfBlogDal());
        CategoryManager CM = new CategoryManager(new EfCategoryDal());
        BlogValidator BV = new BlogValidator();

        public IActionResult Home()
        {
            var values = BM.GetListWithCategory();
            //var query = (from BMx in BM.GetAll()
            //             join CMx in CM.GetAll() on BMx.CategoryID equals CMx.CategoryID
            //             select new
            //             { Name = BMx.BlogTittle, SurName = CMx.CategoryName }).ToList();

            return View(values);

        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.ID = id;
            var values = BM.GetAllByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter(int id)
        {
            var values = BM.GetListWithCategoryByWriterID(id);
            return View(values);
        }
        public IActionResult BlogDelete(int id)
        {
            var values = BM.GetByID(id);
            values.BlogStatus = false;
            BM.Update(values);
            return RedirectToAction("BlogListByWriter");
        }
        public IActionResult BlogUpdate(int id)
        {
            var values = BM.GetByID(id);
            combo();
            return View(values);
        }
        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {
            combo();
            BM.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }
        public IActionResult BlogAdd()
        {
            combo();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var result = BV.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;
                BM.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            combo();
            return View();
        }
        public void combo()
        {
            List<SelectListItem> ComboBox = (from x in CM.GetAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.combo = ComboBox;
        }
    }
}
