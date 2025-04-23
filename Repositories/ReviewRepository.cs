using Microsoft.EntityFrameworkCore;
using SkillTrade.Data;
using SkillTrade.Entities;
using SkillTrade.Interfaces;

namespace SkillTrade.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly SkillTradeDbContext _context;

        public ReviewRepository(SkillTradeDbContext context)
        {
            _context = context;
        }

        public async Task<Review?> GetReviewById(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        public async Task<Review> CreateReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            await _context.Entry(review).Reference(r => r.Service).LoadAsync();

            return review;
        }
        public async Task DeleteReview(int reviewId)
        {
            await _context.Reviews.Where(r => r.Id == reviewId).ExecuteDeleteAsync();
        }
    }
}
