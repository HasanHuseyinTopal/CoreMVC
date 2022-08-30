using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace CoreMVC.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager NM = new NotificationManager(new EfNotificationDal());
        public IActionResult AllNatification()
        {
            var values = NM.GetAll();
            //foreach (var item in values)
            //{
            //    item.NotificationDateTime = Convert.ToDateTime(DateTime.Now - item.NotificationDateTime);
            //}
            return View(values);
        }
    }
}
