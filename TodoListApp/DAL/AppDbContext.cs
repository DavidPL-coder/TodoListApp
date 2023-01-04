using Microsoft.EntityFrameworkCore;
using TodoListApp.DAL.Entities;

namespace TodoListApp.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(user => user.Id).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired();
            modelBuilder.Entity<User>().HasIndex(user => user.Name).IsUnique();
            modelBuilder.Entity<User>().Property(user => user.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired();
        }
    }
}
