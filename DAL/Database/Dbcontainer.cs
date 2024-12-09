using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL.Entities;

namespace WebApplication2.DAL.Database
{
    public class Dbcontainer : IdentityDbContext
    {
        public Dbcontainer()
        {
        }

        public Dbcontainer(DbContextOptions<Dbcontainer> options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
