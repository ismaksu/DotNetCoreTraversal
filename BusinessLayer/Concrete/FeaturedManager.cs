using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeaturedManager : IFeaturedService
    {
        IFeaturedDAL _featuredDal;

        public FeaturedManager(IFeaturedDAL featuredDal)
        {
            _featuredDal = featuredDal;
        }

        public void AddEntity(Featured t)
        {
            _featuredDal.Insert(t);
        }

        public void DeleteEntity(Featured t)
        {
            _featuredDal.Delete(t);
        }

        public Featured FindEntityByID(int id)
        {
            return _featuredDal.GetByID(id);
        }

        public List<Featured> ListEntities()
        {
            return _featuredDal.GetList();
        }

        public List<Featured> ListEntitiesByFilter(Expression<Func<Featured, bool>> filter)
        {
            return _featuredDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Featured t)
        {
            _featuredDal.Update(t);
        }
    }
}
