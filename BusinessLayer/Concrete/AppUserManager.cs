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
    public class AppUserManager : IAppUserService
    {
        IAppUserDAL _appUserDal;

        public AppUserManager(IAppUserDAL appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void AddEntity(AppUser t)
        {
            _appUserDal.Insert(t);
        }

        public void DeleteEntity(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser FindEntityByID(int id)
        {
            return _appUserDal.GetByID(id);
        }

        public List<AppUser> ListEntities()
        {
            return _appUserDal.GetList();
        }

        public List<AppUser> ListEntitiesByFilter(Expression<Func<AppUser, bool>> filter)
        {
            return _appUserDal.GetListByFilter(filter);
        }

        public void UpdateEntity(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}
