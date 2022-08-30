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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Add(Message Entity)
        {
            _messageDal.Add(Entity);
        }

        public void Delete(Message Entity)
        {
            _messageDal.Delete(Entity);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public Message GetByID(int ID)
        {
            return _messageDal.Get(x => x.MessageID == ID);
        }

        public List<Message> GetMessagesByWriterMail(string mail)
        {
            return _messageDal.GetAll(x => x.Receiver == mail);
        }

        public void Update(Message Entity)
        {
            _messageDal.Update(Entity);
        }
    }
}
