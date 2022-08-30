using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericDal<T> : IGenericDal<T> where T : class, new()
    {
        public void Add(T Entity)
        {
            using (Context cx = new Context())
            {
                cx.Entry(Entity).State = EntityState.Added;
                cx.SaveChanges();
            }
        }

        public void Delete(T Entity)
        {
            using (Context cx= new Context())
            {
                cx.Entry(Entity).State = EntityState.Deleted;
                cx.SaveChanges();
            }
        }
        public void Update(T Entity)
        {
            using (Context cx = new Context())
            {
                cx.Entry(Entity).State = EntityState.Modified;
                cx.SaveChanges();
            }
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            using (Context cx = new Context())
            {
                return cx.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (Context cx= new Context())
            {
                return filter == null ? cx.Set<T>().ToList() :
               cx.Set<T>().Where(filter).ToList();
            }
        }

      
    }
}
