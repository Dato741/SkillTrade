using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Entities;
using SkillTrade.Interfaces;
using SkillTrade.Mapping;

namespace SkillTrade.Controllers
{
    [ApiController]
    [Route("api/review")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IBookingRepository _bookingRepo;
        private readonly IProfileRepository _profileRepo;
        private string Guid => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public ReviewController(IReviewRepository review, IBookingRepository bookingRepository, IProfileRepository profileRepository)
        {
            _reviewRepo = review;
            _bookingRepo = bookingRepository;
            _profileRepo = profileRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto createReviewDto)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);
            Booking? existingBooking = await _bookingRepo.CheckExistingBooking(profileId, createReviewDto.ServiceId);

            if (existingBooking == null) return BadRequest("You must have service booked to leave a review");

            Review review = createReviewDto.ToReviewEntity();
            review.ProfileId = profileId;

            await _reviewRepo.CreateReview(review);

            return Created();
        }

        [HttpDelete("{reviewId}")]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);
            Review? existingReview = await _reviewRepo.GetReviewById(reviewId);

            if(existingReview == null || existingReview.ProfileId != profileId) 
                return NotFound("Review not found");

            await _reviewRepo.DeleteReview(reviewId);

            return NoContent();
        }
    }
}
