using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review?> GetReviewById(int reviewId);
        public Task<Review> CreateReview(Review review);
        public Task DeleteReview(int reviewId);
    }
}
