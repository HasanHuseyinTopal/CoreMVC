using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.Category
{
    public class CategoryList : ViewComponent
    {
       CategoryManager CM = new CategoryManager(new EfCategoryDal());
       public IViewComponentResult Invoke()
        {
            var values = CM.GetAll();
            return View(values);
        }
    }
}
