using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsDAL:IGenericDAL<ContactUs>
    {
        List<ContactUs> ActiveContactList();
        List<ContactUs> PassiveContactList();
        void ChangeContactState(int id);
    }
}
