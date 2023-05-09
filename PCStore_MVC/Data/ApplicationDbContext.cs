﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCStore_MVC.Models.ModelDB;

namespace PCStore_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.HasDefaultSchema("Identity");
			builder.Entity<ApplicationUser>(
				entity => { entity.ToTable(name: "User"); }
			);

			builder.Entity<IdentityRole>(
				entity => { entity.ToTable(name: "Role"); }
			);

			builder.Entity<IdentityUserRole<string>>(
				entity => { entity.ToTable(name: "UserRoles"); }
			);

			builder.Entity<IdentityUserClaim<string>>(
				entity => { entity.ToTable(name: "UserClaims"); }
			);

			builder.Entity<IdentityUserLogin<string>>(
				entity => { entity.ToTable(name: "UserLogins"); }
			);

			builder.Entity<IdentityRoleClaim<string>>(
				entity => { entity.ToTable(name: "RoleClaims"); }
			);

			builder.Entity<IdentityUserToken<string>>(
				entity => { entity.ToTable(name: "UserTokens"); }
			);

		}

		public virtual DbSet<BasketProduct> BasketProducts { get; set; }

		public virtual DbSet<Category> Categories { get; set; }

		public virtual DbSet<Order> Orders { get; set; }

		public virtual DbSet<OrderDetail> OrderDetails { get; set; }

		public virtual DbSet<Producer> Producers { get; set; }

		public virtual DbSet<Product> Products { get; set; }
    }
}