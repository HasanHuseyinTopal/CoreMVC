using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Components.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager NM = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var result = NM.GetAll();
            return View(result);
        } 
    }
}
