using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager WM = new WriterManager(new EfWriterDal());
        WriterValidator WV = new WriterValidator();
        CityManager CM = new CityManager(new EfCityDal());
        public IActionResult SignUp()
        {
            Combo();
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Writer writer)
        {
            var result = WV.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                WM.Add(writer);
                return RedirectToAction("Home", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            Combo();
            return View();
        }
        public void Combo()
        {
            List<SelectListItem> Combo = (from x in CM.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.CityName,
                                              Value = x.CityID.ToString()
                                          }).ToList();
            ViewBag.Combo = Combo;
        }
    }
}
