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
        } 
    }
}
