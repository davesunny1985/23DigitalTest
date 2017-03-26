using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalTestApp.Core.Entities;

namespace DigitalTestApp.Infrastructure
{
    public class DigitalTestAppContext : IdentityDbContext
    {
        //public DbSet<User> TestUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DigitalTestAppContext(DbContextOptions<DigitalTestAppContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Product>()
              .ToTable("tblProducts");

            base.OnModelCreating(builder);
        }
    }
}
