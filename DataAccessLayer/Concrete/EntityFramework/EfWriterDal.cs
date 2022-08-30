using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfWriterDal : GenericDal<Writer>, IWriterDal
    {
        public List<Writer> GetAllCities()
        {
            using (Context cx= new Context())
            {
                return cx.writers.Include(x => x.City).ToList();
            }
        }
    }
}
