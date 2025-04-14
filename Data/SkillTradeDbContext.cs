using Microsoft.EntityFrameworkCore;
using SkillTrade.Entities;

namespace SkillTrade.Data
{
    public class SkillTradeDbContext : DbContext
    {
        public SkillTradeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ServiceListing> ServiceListings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
