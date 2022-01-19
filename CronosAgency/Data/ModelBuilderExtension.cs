using CronosAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace CronosAgency.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
                new Member { Name = "João", Surname = "" },
                new Member { Name = "Maria", Surname = "" },
                new Member { Name = "José", Surname = "" });
				
            modelBuilder.Entity<Service>().HasData(
                new Service { Name = "Desenvolvimento", Description = "Desenvolvimento" },
                new Service { Name = "Design", Description = "Design" },
                new Service { Name = "Consultoria", Description = "Consultoria" });

            modelBuilder.Entity<Post>().HasData(
                new Post { Name = "Post 1", Title = "POST 1", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF"},
				new Post { Name = "Post 2", Title = "POST 2", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF"},
				new Post { Name = "Post 3", Title = "POST 3", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF"}
				);

            modelBuilder.Entity<Role>().HasData(
                new Role { Name = "Administrador", NormalizedName = "Administrador" },
                new Role { Name = "User", NormalizedName = "User" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Name = "Admin", Email = "admim@cronosagency.com", Password = "admin",
                    CreateDate = new System.DateTime(), LastTimePasswordChanged = new System.DateTime(),
                    RoleId = 1 },
                new User { Name = "User", Email = "user@cronosagency.com", Password = "user",
                    CreateDate = new System.DateTime(),
                    LastTimePasswordChanged = new System.DateTime(),
                    RoleId = 2 }
                );
        }
    }
}
