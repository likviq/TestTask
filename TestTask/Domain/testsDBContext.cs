using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Models;

namespace TestTask.Domain
{
    public class testsDBContext : DbContext
    {
        public testsDBContext(DbContextOptions<testsDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { IdUser = 1, Username = "user1", Password = "password123" },
                new User { IdUser = 2, Username = "user2", Password = "password123" }
                );
        }
    }
}
