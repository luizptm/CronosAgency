using Microsoft.EntityFrameworkCore;

namespace CronosAgency.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Name = "João", Surname = "" },
                new Member { Id = 2, Name = "Maria", Surname = "" },
                new Member { Id = 3, Name = "José", Surname = "" });
				
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Desenvolvimento" },
                new Service { Id = 2, Name = "Design" },
                new Service { Id = 3, Name = "Consultoria" });

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Name = "Post 1", Title = "POST 1", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF"},
				new Post { Id = 2, Name = "Post 2", Title = "POST 2", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF"},
				new Post { Id = 3, Name = "Post 3", Title = "POST 3", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF"}
				);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email = "admim@cronosagency.com", Password = "admin" },
                new User { Id = 2, Name = "User", Email = "user@cronosagency.com", Password = "user" }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrador", NormalizedName = "Administrador" },
                new Role { Id = 2, Name = "User", NormalizedName = "User" }
                );
        }
    }
}
