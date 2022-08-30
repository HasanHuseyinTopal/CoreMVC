using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager CM = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var values = CM.GetAll();
            return View(values);
        }
    }
}
