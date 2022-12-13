using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Models;

namespace TestTask.Domain
{
    public class testsDBContext : DbContext
    {
        public testsDBContext(DbContextOptions<testsDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { IdUser = 1, Username = "user1", Password = "password123" },
                new User { IdUser = 2, Username = "user2", Password = "password123" }
                );
        }
    }
}
