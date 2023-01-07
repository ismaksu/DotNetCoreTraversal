using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericUowDAL<T> where T : class
    {
        void Insert(T t);

        void Update(T t);

        T GetByID(int id);

        void MultiUpdate(List<T> t);
    }
}
