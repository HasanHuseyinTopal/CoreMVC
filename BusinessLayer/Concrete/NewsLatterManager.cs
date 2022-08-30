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
    public class NewsLatterManager : INewsLatterService
    {
        INewsLatterDal _newsLatterDal;
        public NewsLatterManager(INewsLatterDal newsLatterDal)
        {
            _newsLatterDal = newsLatterDal;
        }
      

        public void Add(NewsLatter newsLatter)
        {
            _newsLatterDal.Add(newsLatter);
        }

        public void Delete(NewsLatter newsLatter)
        {
            _newsLatterDal.Delete(newsLatter);
        }

        public void Update(NewsLatter newsLatter)
        {
            _newsLatterDal.Update(newsLatter);
        }
        public List<NewsLatter> GetAll()
        {
            return _newsLatterDal.GetAll();
        }

        public NewsLatter GetByID(int ID)
        {
            return _newsLatterDal.Get(x => x.MailID == ID);
        }
    }
}
