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
    public class ReservationManager : IReservationService
    {
        IReservationDAL _reservationDal;

        public ReservationManager(IReservationDAL reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void AddEntity(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void DeleteEntity(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation FindEntityByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> GetAcceptedReservation(int id)
        {
            return _reservationDal.GetAcceptedReservation(id);
        }

        public List<Reservation> GetApprovalReservation(int id)
        {
            return _reservationDal.GetApprovalReservation(id);
        }

        public List<Reservation> GetPreviousReservation(int id)
        {
            return _reservationDal.GetPreviousReservation(id);
        }

        public Reservation GetReservationByID(int id)
        {
            return _reservationDal.GetReservationByID(id);
        }

        public List<Reservation> ListEntities()
        {
            return _reservationDal.GetList();
        }

        public List<Reservation> ListEntitiesByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
