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

        public DbSet<Profile> Profiles { get; set; }
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

            builder.Entity<UserIdentity>().HasData(
                new UserIdentity
                {
                    Id = "3e55614e-6d26-4f71-9db5-0f7b3cc880fc",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@app.com",
                    NormalizedEmail = "ADMIN@APP.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEEZUbfvj9wdorBngRTEHr1wYeG24CeMolHtwP9Rirb98ZuwA5d3K/pTH3NthOP6Wvw==",
                    SecurityStamp = "dcb84c17-f78e-4ddf-9c84-3d60c4a66e29",
                    ConcurrencyStamp = "9f937aa7-27e5-4dc3-a038-9861d5c8f13b"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "3e55614e-6d26-4f71-9db5-0f7b3cc880fc",
                    RoleId = "1"
                }
            );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Plumbing" },
                new Category { Id = 2, Name = "Electrical" },
                new Category { Id = 3, Name = "Home Cleaning" },
                new Category { Id = 4, Name = "Web Development" },
                new Category { Id = 5, Name = "Graphic Design" },
                new Category { Id = 6, Name = "Tutoring" },
                new Category { Id = 7, Name = "Pet Services" },
                new Category { Id = 8, Name = "Fitness Coaching" },
                new Category { Id = 9, Name = "Translation" },
                new Category { Id = 10, Name = "Photography" }
            );


            builder.Entity<Profile>()
                .HasMany(u => u.ServiceList)
                .WithOne(s => s.Profile)
                .HasForeignKey(s => s.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ServiceListing>()
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ServiceListing>()
                .HasMany(s => s.Reviews)
                .WithOne(r => r.Service)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(b => b.Profile)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(b => b.Service)
                .WithMany()
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(r => r.Profile)
                .WithMany()
                .HasForeignKey(r => r.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
