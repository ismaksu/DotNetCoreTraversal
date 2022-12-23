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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDAL _announcementDal;

        public AnnouncementManager(IAnnouncementDAL announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AddEntity(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void DeleteEntity(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement FindEntityByID(int id)
        {
            return _announcementDal.GetByID(id);
        }

        public List<Announcement> ListEntities()
        {
            return _announcementDal.GetList();
        }

        public List<Announcement> ListEntitiesByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return _announcementDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Announcement t)
        {
            _announcementDal.Update(t);
        }
    }
}
