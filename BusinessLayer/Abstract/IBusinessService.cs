using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBusinessService<T>
    {
        void Add(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
        List<T> GetAll();
        T GetByID(int ID);
    }
}
