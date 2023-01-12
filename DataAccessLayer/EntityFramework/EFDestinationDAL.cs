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
    public class EFDestinationDAL : GenericRepository<Destination>, IDestinationDAL
    {

        public List<Destination> GetDestinationByCity(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations
                    .Include(x => x.City)
                    .Where(x => x.CityID == id)
                    .ToList();
            }
        }

        public Destination GetDestinationByID(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations
                        .Include(x => x.City)
                        .Where(x => x.DestinationID == id)
                        .FirstOrDefault();
            }
        }

        public List<Destination> ListDestination()
        {
            using (var c = new Context())
            {
                return c.Destinations
                        .Include(x => x.City)
                        .ToList();
            }
        }
    }
}
