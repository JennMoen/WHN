using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;

namespace GroupProject.Data
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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<UserGroup>()
                  .HasKey(x => new { x.UserId, x.GroupId });
            builder.Entity<EventGroup>()
                  .HasKey(x => new { x.EventId, x.GroupId });
            builder.Entity<EventUser>()
                  .HasKey(x => new { x.EventId, x.UserId });
        }


        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<EventGroup> EventGroups { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }

    }
}
