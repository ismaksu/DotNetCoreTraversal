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
    public class GuideManager : IGuideService
    {
        IGuideDAL _guideDal;

        public GuideManager(IGuideDAL guideDal)
        {
            _guideDal = guideDal;
        }

        public void AddEntity(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void ChangeGuideStat(int id)
        {
            _guideDal.ChangeGuideStat(id);
        }

        public void DeleteEntity(Guide t)
        {
            _guideDal.Delete(t);
        }

        public Guide FindEntityByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> ListEntities()
        {
            return _guideDal.GetList();
        }

        public List<Guide> ListEntitiesByFilter(Expression<Func<Guide, bool>> filter)
        {
            return _guideDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Guide t)
        {
            _guideDal.Update(t);
        }
    }
}
