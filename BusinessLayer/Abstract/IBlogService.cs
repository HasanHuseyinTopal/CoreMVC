using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IBusinessService<Blog>
    {
        List<Blog> GetAllByID(int id);
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriterID(int id);
        List<Blog> GetBlogListByWriterID(int ID);
        List<Blog> GetLastBlogsAt7Days();
    }
}
