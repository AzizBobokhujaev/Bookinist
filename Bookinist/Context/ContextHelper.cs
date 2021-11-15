using Bookinist.Models.Account;
using Bookinist.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Context
{
    public static class ContextHelper
    {
        public static async Task Seeding(BookinistContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Where(p=>p.NormalizedName.Equals("Admin")).Any())
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                await roleManager.CreateAsync(adminRole);
            }
            if (!userManager.Users.Where(p=>p.UserName.Equals("Admin")).Any())
            {
                var adminUser = new User
                {
                    UserName = "Admin",
                    Email = "Admin@mail.ru"
                };
                var result = await userManager.CreateAsync(adminUser, "password");

                if (result.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Admin");

                    await userManager.AddToRoleAsync(await userManager.FindByNameAsync("Admin"), role.Name);
                }

                if (!context.Categories.Any())
                {
                    var categories = new List<Category>
                    {
                        new Category { Id = 1, Name = "Детектив"},
                        new Category { Id = 2, Name = "Фантастика"},
                        new Category { Id = 3, Name = "Приключения"},
                        new Category { Id = 4, Name = "Роман"},
                        new Category { Id = 5, Name = "Научная книга"},
                        new Category { Id = 6, Name = "Фольклор"},
                        new Category { Id = 7, Name = "Юмор"},
                        new Category { Id = 8, Name = "Справочная книга"}
                    };
                }

            }
        } 
    }
}
