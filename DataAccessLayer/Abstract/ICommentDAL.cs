using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDAL:IGenericDAL<Comment>
    {
        public List<Comment> ListCommentWithDestination();
        public List<Comment> ListCommentByDestination(int id);
        public List<Comment> ListCommentByUser(int id);
        public Comment GetCommentWithDestination(int id);
    }
}
