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
    public class BlogManager : IBlogService
    {
        IBlogDal _BlogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _BlogDal = blogDal;
        }
        public void Add(Blog blog)
        {
            _BlogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _BlogDal.Delete(blog);
        }

        public void Update(Blog blog)
        {
            _BlogDal.Update(blog);
        }

        public List<Blog> GetAll()
        {
            return _BlogDal.GetAll();
        }
        public Blog GetByID(int ID)
        {
            return _BlogDal.Get(x => x.BlogID == ID);
        }
        public List<Blog> GetAllByID(int id)
        {
            return _BlogDal.GetAll(x=> x.BlogID==id);
        }       
        public List<Blog> GetListWithCategory()
        {
            return _BlogDal.GetListWithCategory();

        }
        public List<Blog> GetBlogListByWriterID(int ID)
        {
            return _BlogDal.GetAll(x => x.WriterID == ID);
        }
        public List<Blog> GetLeast3Blog()
        {
           return _BlogDal.GetAll().TakeLast(3).ToList();
        }

        public List<Blog> GetListWithCategoryByWriterID(int id)
        {
            return _BlogDal.GetListWithCategoryByWriterID(id);
        }

        public List<Blog> GetLastBlogsAt7Days()
        {
            return _BlogDal.GetAll(x => x.BlogCreateDate.AddDays(7) >= DateTime.Now);
        }
    }
}
