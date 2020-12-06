using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_P34.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_P34.DataAccess
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options): base(options) { }
        public DbSet<UserMoreInfo> userMoreInfos { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Announcement> announcements { get; set; }
        public DbSet<Actor> actors { get; set; }
        public DbSet<Photo> photos { get; set; }
        public DbSet<Review> reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.UserMoreInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserMoreInfo>(ui => ui.Id);

            base.OnModelCreating(builder);
        }


    }
}
