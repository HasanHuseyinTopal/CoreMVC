using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification Entity)
        {
            _notificationDal.Add(Entity);
        }
        public void Update(Notification Entity)
        {
            _notificationDal.Update(Entity);
        }

        public void Delete(Notification Entity)
        {
            _notificationDal.Delete(Entity);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetByID(int ID)
        {
            return _notificationDal.Get(x=> x.NotificationID==ID);
        }
    }
}
