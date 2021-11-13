using Bookinist.Entity;
using Bookinist.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bookinist.Context
{
    public class BookinistContext : IdentityDbContext<User>
    {
        public BookinistContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity => entity.ToTable("Users"));
            builder.Entity<IdentityRole>(e => e.ToTable("Roles"));
            builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(e => e.ToTable("UserClaims"));
            builder.Entity<IdentityUserLogin<string>>(e => e.ToTable("UserLogins"));
            builder.Entity<IdentityUserToken<string>>(e => e.ToTable("UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(e => e.ToTable("RoleClaims"));

        }
    }
}
