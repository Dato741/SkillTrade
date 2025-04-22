using SkillTrade.Dtos.ToClient;
using SkillTrade.Entities;

namespace SkillTrade.Mapping
{
    public static class BookingMapping
    {
        public static BookingDto ToBookingDto(this Booking booking)
        {
            return new BookingDto
            {
                BookingId = booking.Id,
                ServiceName = booking.Service!.Name,
                ServiceDescription = booking.Service!.Description,
                PayOffered = booking.Service!.PayOffered
            };
        }
    }
}
