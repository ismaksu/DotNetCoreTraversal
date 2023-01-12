using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDAL:IGenericDAL<Destination>
    {
        public List<Destination> ListDestination();
        public Destination GetDestinationByID(int id);
        public List<Destination> GetDestinationByCity(int id);
    }
}
