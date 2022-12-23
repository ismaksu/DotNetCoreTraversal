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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDAL _contactUsDal;

        public ContactUsManager(IContactUsDAL contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public List<ContactUs> ActiveContactList()
        {
            return _contactUsDal.ActiveContactList();
        }

        public void AddEntity(ContactUs t)
        {
            _contactUsDal.Insert(t);
        }

        public void ChangeContactState(int id)
        {
            _contactUsDal.ChangeContactState(id);
        }

        public void DeleteEntity(ContactUs t)
        {
            _contactUsDal.Delete(t);
        }

        public ContactUs FindEntityByID(int id)
        {
            return _contactUsDal.GetByID(id);
        }

        public List<ContactUs> ListEntities()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> ListEntitiesByFilter(Expression<Func<ContactUs, bool>> filter)
        {
            return _contactUsDal.GetListByFilter(filter);
        }

        public List<ContactUs> PassiveContactList()
        {
            return _contactUsDal.PassiveContactList();
        }

        public void UpdateEntity(ContactUs t)
        {
            _contactUsDal.Update(t);
        }
    }
}
