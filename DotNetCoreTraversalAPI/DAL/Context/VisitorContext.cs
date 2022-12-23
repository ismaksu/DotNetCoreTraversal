using DotNetCoreTraversalAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTraversalAPI.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CodersPC\SQLEXPRESS; Initial Catalog=ApiDb_CoreTraversal; Integrated Security=True;");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
