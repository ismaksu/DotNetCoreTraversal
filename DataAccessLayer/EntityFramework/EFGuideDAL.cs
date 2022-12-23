using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFGuideDAL : GenericRepository<Guide>, IGuideDAL
    {
        public void ChangeGuideStat(int id)
        {
            Context c = new Context();
            var guide = c.Guides.Find(id);

            guide.Status = guide.Status ? false : true;

            c.SaveChanges();
        }
    }
}
