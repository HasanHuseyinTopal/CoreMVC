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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _CategoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _CategoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _CategoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _CategoryDal.Delete(category);
        }

        public void Update(Category category)
        {
            _CategoryDal.Update(category);
        }

        public Category GetByID(int ID)
        {
            return _CategoryDal.Get(x=> x.CategoryID==ID);
        }

        public List<Category> GetAll()
        {
            return _CategoryDal.GetAll();
        }

        public List<Category> GetAllByID(int ID)
        {
            return _CategoryDal.GetAll(x=> x.CategoryID==ID);
        }
    }
}
