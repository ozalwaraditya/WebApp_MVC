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
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Name="Aditya", Email="aditya@gmail.com", Password = "aditya"},
        //        new User { Id = 2, Name="Tanmay", Email="tanmay@gmail.com", Password = "tanmay"},
        //        new User { Id = 3, Name="Martand", Email="martand@gmail.com", Password = "martand"}
        //        );
        //}
    }
}
