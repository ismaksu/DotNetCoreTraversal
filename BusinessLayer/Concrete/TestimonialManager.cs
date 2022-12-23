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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDAL _testimonialDal;

        public TestimonialManager(ITestimonialDAL testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void AddEntity(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        public void DeleteEntity(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public Testimonial FindEntityByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public List<Testimonial> ListEntities()
        {
            return _testimonialDal.GetList();
        }

        public List<Testimonial> ListEntitiesByFilter(Expression<Func<Testimonial, bool>> filter)
        {
            return _testimonialDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Testimonial t)
        {
            _testimonialDal.Update(t);
        }
    }
}
