using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<Comment> ListCommentsByDestination(int id);
        public List<Comment> ListCommentWithDestination();
        public List<Comment> ListCommentByUser(int id);
        public Comment GetCommentWithDestination(int id);
    }
}
