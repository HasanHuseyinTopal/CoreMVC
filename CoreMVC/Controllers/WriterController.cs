using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreMVC.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class WriterController : Controller
    {
        WriterManager WM = new WriterManager(new EfWriterDal());
        CityManager CM = new CityManager(new EfCityDal());
        WriterValidator WV = new WriterValidator();
        public IActionResult Home()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        public IActionResult WriterEditProfile()
        {
            Combo();
                                          
            var values = WM.GetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            Combo();
            var result = WV.Validate(writer);
            if (result.IsValid)
            {
                writer.WriterStatus = true;
                WM.Update(writer);
                return RedirectToAction("Home", "DashBoard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("WriterEditProfile","Writer");
        }
        public IActionResult WriterAdd()
        {
            Combo();
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer W = new Writer();
            Combo();
            if (writer.WriterImage != null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newImageName = Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFolder/",newImageName);
                var stream = new FileStream(location,FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                W.WriterImage = newImageName;
            }
            W.CityID = writer.CityID;
            W.WriterMail = writer.WriterMail;
            W.WriterName = writer.WriterName;
            W.WriterPassword = writer.WriterPassword;
            W.WriterStatus = true;
            W.WriterAbout = writer.WriterAbout;
            WM.Add(W);
            return RedirectToAction("Home", "DashBoard");
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
