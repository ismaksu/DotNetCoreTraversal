using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDAL : GenericRepository<Reservation>, IReservationDAL
    {
        public List<Reservation> GetAcceptedReservation(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .Where(x => x.ReservationStat == "Rezervasyon Onaylandı" && x.AppUserId == id)
                    .ToList();
            }
        }

        public List<Reservation> GetApprovalReservation(int id)
        {
            using(var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .Where(x => x.ReservationStat == "Rezervasyon Onay Bekliyor.." && x.AppUserId == id)
                    .ToList();
            }
        }

        public List<Reservation> GetPreviousReservation(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .Include(y => y.AppUser)
                    .Where(x => x.ReservationStat == "Geçmiş Rezervasyon" && x.AppUserId == id)
                    .ToList();
            }
        }

        public Reservation GetReservationByID(int id)
        {
            using (var c = new Context())
            {
                return c.Reservations
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .Include(x => x.AppUser)
                    .Where(x => x.ReservationID == id)
                    .FirstOrDefault();
            }
        }
    }
}
