using Microsoft.EntityFrameworkCore;
using SkillTrade.Data;
using SkillTrade.Entities;
using SkillTrade.Interfaces;

namespace SkillTrade.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly SkillTradeDbContext _context;

        public BookingRepository(SkillTradeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllBookingsAsync(int profileId)
        {
            return await _context.Bookings.Where(b => b.ProfileId == profileId)
                .Include(b => b.Service).ToListAsync();
        }

        public async Task<Booking?> GetBookingAsync(int profileId, int bookingId)
        {
            return await _context.Bookings.Include(b => b.Service).FirstOrDefaultAsync(b => b.ProfileId == profileId &&
                b.Id == bookingId);
        }

        public async Task<Booking?> CheckExistingBooking(int profileId, int serviceId)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.ProfileId == profileId &&
                b.ServiceId == serviceId);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            await _context.Bookings.Entry(booking).Reference(b => b.Service).LoadAsync();

            return booking;
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            await _context.Bookings.Where(b => b.Id == bookingId).ExecuteDeleteAsync();
        }
    }
}
