using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    }
}
