using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Entities;

namespace SkillTrade.Mapping
{
    public static class ReviewMapping
    {
        public static ReviewDto ToReviewDto(this Review review)
        {
            return new ReviewDto
            {
                ReviewAuthor = review.Profile?.Name,
                Comment = review.Comment,
                ServiceName = review.Service?.Name
            };
        }

        public static Review ToReviewEntity(this CreateReviewDto createReviewDto)
        {
            return new Review
            {
                Comment = createReviewDto.Comment,
                ServiceId = createReviewDto.ServiceId
            };
        }
    }
}
