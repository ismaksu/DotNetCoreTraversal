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
    public class DestinationManager : IDestinationService
    {

        IDestinationDAL _destinationDal;

        public DestinationManager(IDestinationDAL destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void AddEntity(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void DeleteEntity(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination FindEntityByID(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public List<Destination> GetDestinationByCity(int id)
        {
            return _destinationDal.GetDestinationByCity(id);
        }

        public Destination GetDestinationByID(int id)
        {
            return _destinationDal.GetDestinationByID(id);
        }

        public List<Destination> ListDestination()
        {
            return _destinationDal.ListDestination();
        }

        public List<Destination> ListEntities()
        {
            return _destinationDal.GetList();
        }

        public List<Destination> ListEntitiesByFilter(Expression<Func<Destination, bool>> filter)
        {
            return _destinationDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Destination t)
        {
            _destinationDal.Update(t);
        }
    }
}
