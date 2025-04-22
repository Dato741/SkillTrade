using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface IBookingRepository
    {
        public Task<List<Booking>> GetAllBookingsAsync(int profileId);
        public Task<Booking?> GetBookingAsync(int profileId, int bookingId);
        public Task<Booking?> CheckExistingBooking(int profileId, int serviceId);
        public Task<Booking> CreateBookingAsync(Booking booking);
        public Task DeleteBookingAsync(int bookingId);
    }
}
