using CronosAgency.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CronosAgency.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CronosAgencyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Members.Any())
            {
                return;
            }

            var members = new Member[]
            {
                new Member { Name = "João", Surname = "" },
                new Member { Name = "Maria", Surname = "" },
                new Member { Name = "José", Surname = "" }
            };
            context.AddRange(members);
            context.SaveChanges();

            var services = new Service[]
            {
                new Service { Name = "Desenvolvimento", Description = "Desenvolvimento" },
                new Service { Name = "Design", Description = "Design" },
                new Service { Name = "Consultoria", Description = "Consultoria" }
            };
            context.AddRange(services);
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post { Name = "Post 1", Title = "POST 1", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF" },
                new Post { Name = "Post 2", Title = "POST 2", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF" },
                new Post { Name = "Post 3", Title = "POST 3", Content = "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF" }
             };
            context.AddRange(posts);
            context.SaveChanges();

            var roles = new Role[]
            {
                new Role { Name = "Administrador", NormalizedName = "Administrador" },
                new Role { Name = "User", NormalizedName = "User" }
            };
            context.AddRange(roles);
            context.SaveChanges();

            var users = new User[]
            {
                new User
                {
                    Name = "Admin",
                    Email = "admim@cronosagency.com",
                    Password = "admin",
                    CreateDate = new System.DateTime(),
                    LastTimePasswordChanged = new System.DateTime(),
                    RoleId = 1
                },
                new User
                {
                    Name = "User",
                    Email = "user@cronosagency.com",
                    Password = "user",
                    CreateDate = new System.DateTime(),
                    LastTimePasswordChanged = new System.DateTime(),
                    RoleId = 1
                }
            };
            context.AddRange(users);
            context.SaveChanges();
        }
    }
}
