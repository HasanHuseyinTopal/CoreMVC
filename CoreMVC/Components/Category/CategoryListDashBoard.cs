using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.Category
{
   
    public class CategoryListDashBoard : ViewComponent
    {
        CategoryManager CM = new CategoryManager(new EfCategoryDal()); 
        public IViewComponentResult Invoke()
        {
            var result= CM.GetAll();
            return View(result);
        }
    }
}
