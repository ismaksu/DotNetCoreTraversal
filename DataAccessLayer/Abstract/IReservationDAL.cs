using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDAL:IGenericDAL<Reservation>
    {
        List<Reservation> GetApprovalReservation(int id);
        List<Reservation> GetAcceptedReservation(int id);
        List<Reservation> GetPreviousReservation(int id);
        Reservation GetReservationByID(int id);
    }
}
