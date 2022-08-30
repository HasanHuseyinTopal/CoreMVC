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
    public class EfBlogDal : GenericDal<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (Context cx = new Context())
            {
                return cx.blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriterID(int id)
        {
            using (Context cx = new Context())
            {
                return cx.blogs.Include(x => x.Category).Where(x=> x.WriterID==id).ToList();
            }
        }
    }
}
