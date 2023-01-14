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
    public class EFCommentDAL : GenericRepository<Comment>, ICommentDAL
    {
        public Comment GetCommentWithDestination(int id)
        {
            using(var c = new Context())
            {
                return c.Comments
                    .Include(x => x.AppUser)
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .Where(x => x.CommentID == id)
                    .FirstOrDefault();
            }
        }

        public List<Comment> ListCommentByDestination(int id)
        {
            using (var c = new Context())
            {
                return c.Comments
                    .Include(x => x.AppUser)
                    .Where(x => x.DestinationID == id)
                    .ToList();
            }
        }

        public List<Comment> ListCommentByUser(int id)
        {
            using (var c = new Context())
            {
                return c.Comments
                    .Include(x => x.AppUser)
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .Where(x => x.AppUserId == id)
                    .ToList();
            }
        }

        public List<Comment> ListCommentWithDestination()
        {
            using (var c = new Context())
            {
                return c.Comments
                    .Include(x => x.Destination)
                    .Include(x => x.Destination.City)
                    .ToList();
            }
        }
    }
}
