using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;

namespace SkillTrade.Mapping
{
    public static class ServiceListingMapping
    {
        public static ServiceListingDto ToServiceListingDto(this ServiceListing serviceListing)
        {
            return new ServiceListingDto
            {
                ServiceId = serviceListing.Id,
                CategoryName = serviceListing.Category!.Name,
                Name = serviceListing.Name,
                Description = serviceListing.Description,
                PayOffered = serviceListing.PayOffered,
                ServicePostedBy = serviceListing.ServicePostedBy,
                Reviews = serviceListing.Reviews?.Select(r => r.ToReviewDto()).ToList()
            };
        }

        public static ServiceListing ToServiceListingEntity(this CreateServiceListingDto createServiceListingDto)
        {
            return new ServiceListing
            {
                Name = createServiceListingDto.Name,
                Description = createServiceListingDto.Description,
                PayOffered = createServiceListingDto.PayOffered,
                CategoryId = createServiceListingDto.CategoryId
            };
        }

        public static ServiceListing ToServiceListingEntity(this UpdateServiceListingDto updateServiceListingDto)
        {
            return new ServiceListing
            {
                Name = updateServiceListingDto.Name,
                Description = updateServiceListingDto.Description,
                PayOffered = updateServiceListingDto.PayOffered,
                CategoryId = updateServiceListingDto.CategoryId
            };
        }
    }
}
