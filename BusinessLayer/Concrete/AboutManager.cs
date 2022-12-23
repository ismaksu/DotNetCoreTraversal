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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDal;

        public AboutManager(IAboutDAL aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AddEntity(About t)
        {
            _aboutDal.Insert(t);
        }

        public void DeleteEntity(About t)
        {
            _aboutDal.Delete(t);
        }

        public About FindEntityByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> ListEntities()
        {
            return _aboutDal.GetList();
        }

        public List<About> ListEntitiesByFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.GetListByFilter(filter);
        }

        public void UpdateEntity(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
