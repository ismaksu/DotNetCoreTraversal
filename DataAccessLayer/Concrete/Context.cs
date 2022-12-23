using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CodersPC\\SQLEXPRESS; Database=Db_CoreTraversal; Integrated Security=True;");
            //optionsBuilder.UseSqlServer("workstation id=DbCoreTraversal.mssql.somee.com;packet size=4096;user id=ismaksu_SQLLogin_1;pwd=8dzlf5s6eu;data source=DbCoreTraversal.mssql.somee.com;persist security info=False;initial catalog=DbCoreTraversal");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Featured> Featureds { get; set; }
        public DbSet<Featured1> Featured1s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ContactUs> tblContactUs { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
    }
}
