using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void AddEntity(T t);
        void DeleteEntity(T t);
        void UpdateEntity(T t);
        List<T> ListEntities();
        T FindEntityByID(int id);
        List<T> ListEntitiesByFilter(Expression<Func<T, bool>> filter);
    }
}
