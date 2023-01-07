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
    public class CommentManager : ICommentService
    {
        ICommentDAL _commentDal;

        public CommentManager(ICommentDAL commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddEntity(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void DeleteEntity(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment FindEntityByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public Comment GetCommentWithDestination(int id)
        {
            return _commentDal.GetCommentWithDestination(id);
        }

        public List<Comment> ListCommentByUser(int id)
        {
            return _commentDal.ListCommentByUser(id);
        }

        public List<Comment> ListCommentsByDestination(int id)
        {
            return _commentDal.ListCommentByDestination(id);
        }

        public List<Comment> ListCommentWithDestination()
        {
            return _commentDal.ListCommentWithDestination();
        }

        public List<Comment> ListEntities()
        {
            return _commentDal.GetList();
        }

        public List<Comment> ListEntitiesByFilter(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.GetListByFilter(filter);
        }

        public void UpdateEntity(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
