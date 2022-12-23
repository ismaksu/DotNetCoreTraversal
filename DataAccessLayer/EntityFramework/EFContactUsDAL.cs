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
    public class EFContactUsDAL : GenericRepository<ContactUs>, IContactUsDAL
    {
        public List<ContactUs> ActiveContactList()
        {
            using (var c = new Context())
            {
                var values = c.tblContactUs.Where(x => x.Status).ToList();
                return values;
            }
        }

        public void ChangeContactState(int id)
        {
            using (var c = new Context())
            {
                var value = c.tblContactUs.Find(id);
                value.Status = value.Status ? false : true;
                c.SaveChanges();
            }
        }

        public List<ContactUs> PassiveContactList()
        {
            using (var c = new Context())
            {
                var values = c.tblContactUs.Where(x => x.Status == false).ToList();
                return values;
            }
        }
    }
}
