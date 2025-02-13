using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

            //Seeding the data to database
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
       
        //}
    }
}
