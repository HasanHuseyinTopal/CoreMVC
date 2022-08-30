using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.WriterMessageNotification
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager MM = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            string Mail = "hasan@gmail.com";
            var result = MM.GetMessagesByWriterMail(Mail);
            return View(result);
        }
    }
}
