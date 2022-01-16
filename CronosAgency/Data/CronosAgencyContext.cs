using CronosAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace CronosAgency.Data
{
    public class CronosAgencyContext : DbContext
    {
        public CronosAgencyContext (DbContextOptions<CronosAgencyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasKey(a => a.Id);
            modelBuilder.Entity<Post>().HasKey(a => a.Id);
            modelBuilder.Entity<Service>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().HasKey(a => a.Id);

            modelBuilder.Seed();
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
