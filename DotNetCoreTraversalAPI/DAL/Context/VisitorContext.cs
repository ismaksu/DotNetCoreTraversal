using DotNetCoreTraversalAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreTraversalAPI.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Connection String");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
