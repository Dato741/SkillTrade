using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Entities;
using SkillTrade.Interfaces;
using SkillTrade.Mapping;

namespace SkillTrade.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IProfileRepository _profileRepo;
        private string Guid => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public BookingController(IBookingRepository bookingRepository, IProfileRepository profileRepository)
        {
            _bookingRepo = bookingRepository;
            _profileRepo = profileRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllBookings()
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            List<Booking> bookings = await _bookingRepo.GetAllBookingsAsync(profileId);
            List<BookingDto> bookingDtos = bookings.Select(b => b.ToBookingDto()).ToList();

            return Ok(bookingDtos);
        }

        [HttpGet("{bookingId}")]
        [Authorize]
        public async Task<IActionResult> GetBookingById(int bookingId)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            Booking? booking = await _bookingRepo.GetBookingAsync(profileId, bookingId);

            if (booking == null) return NotFound($"You don't have booking with id: {bookingId}");

            return Ok(booking.ToBookingDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBooking([FromBody] int serviceId)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            Booking? existingBooking = await _bookingRepo.CheckExistingBooking(profileId, serviceId);
            if (existingBooking != null) return Conflict(new { message = "You have already booked the service" });

            Booking booking = new Booking
            {
                ProfileId = profileId,
                ServiceId = serviceId
            };

            await _bookingRepo.CreateBookingAsync(booking);

            return CreatedAtAction(nameof(GetBookingById), new { bookingId = booking.Id }, booking.ToBookingDto());
        }

        [HttpDelete("{bookingId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            Booking? existingBooking = await _bookingRepo.GetBookingAsync(profileId, bookingId);
            if (existingBooking == null) return NotFound($"You don't have booking with id: {bookingId}");

            await _bookingRepo.DeleteBookingAsync(bookingId);

            return NoContent();
        }
    }
}
