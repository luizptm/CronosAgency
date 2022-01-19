using CronosAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace CronosAgency.Data
{
    public class CronosAgencyContext : DbContext
    {
        public CronosAgencyContext(DbContextOptions<CronosAgencyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Membro");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Service>().ToTable("Servico");
            modelBuilder.Entity<User>().ToTable("Usuario");
            modelBuilder.Entity<Role>().ToTable("Perfil");

            modelBuilder.Entity<Member>().HasKey(a => a.Id);
            modelBuilder.Entity<Member>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Member>().Property(r => r.Surname).IsRequired();

            modelBuilder.Entity<Post>().HasKey(a => a.Id);
            modelBuilder.Entity<Post>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Post>().Property(r => r.Title).IsRequired();
            modelBuilder.Entity<Post>().Property(r => r.Content).IsRequired();

            modelBuilder.Entity<Service>().HasKey(a => a.Id);
            modelBuilder.Entity<Service>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Service>().Property(r => r.Description).IsRequired();

            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.Email).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.Password).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.CreateDate).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.LastTimePasswordChanged).IsRequired();
            modelBuilder.Entity<User>().Property(r => r.RoleId).IsRequired();
            modelBuilder.Entity<User>().HasOne(r => r.Role);
            modelBuilder.Entity<User>().HasOne(r => r.Role).WithMany(r => r.Users).HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Role>().Property(r => r.NormalizedName).IsRequired();
            modelBuilder.Entity<Role>().HasMany(r => r.Users);
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
