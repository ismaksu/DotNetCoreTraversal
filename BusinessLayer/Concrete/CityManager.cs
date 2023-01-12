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
    public class CityManager : ICityService
    {
        private readonly ICityDAL _cityDal;

        public CityManager(ICityDAL cityDal)
        {
            _cityDal = cityDal;
        }

        public void AddEntity(City t)
        {
            _cityDal.Insert(t);
        }

        public void DeleteEntity(City t)
        {
            _cityDal.Delete(t);
        }

        public City FindEntityByID(int id)
        {
            return _cityDal.GetByID(id);
        }

        public List<City> ListEntities()
        {
            return _cityDal.GetList();
        }

        public List<City> ListEntitiesByFilter(Expression<Func<City, bool>> filter)
        {
            return _cityDal.GetListByFilter(filter);
        }

        public void UpdateEntity(City t)
        {
            _cityDal.Update(t);
        }
    }
}
