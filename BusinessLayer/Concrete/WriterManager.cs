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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetByID(int ID)
        {
            return _writerDal.Get(x => x.WriterID == ID);
        }

        public List<Writer> GetAllCity()
        {
            return _writerDal.GetAllCities();
        }

        public List<Writer> GetWriterByID(int ID)
        {
            return _writerDal.GetAll(x => x.WriterID == ID);
        }
    }
}
