using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.Writer
{
    public class WriterAboutOnDashBoard : ViewComponent
    {
        WriterManager WM = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke(int id)
        {
            var result = WM.GetWriterByID(id);
            return View(result);
        }
    }
}
