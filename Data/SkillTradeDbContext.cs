using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SkillTrade.Entities;
using SkillTrade.Identity;

namespace SkillTrade.Data
{
    public class SkillTradeDbContext : IdentityDbContext<UserIdentity>
    {
        public SkillTradeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> UsersSkillTrade { get; set; }
        public DbSet<ServiceListing> ServiceListings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                
                new IdentityRole
                {
                    Id = "1",
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "1"
                },

                new IdentityRole
                {
                    Id = "2",
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "2"
                }
            );
        }
    }
}
