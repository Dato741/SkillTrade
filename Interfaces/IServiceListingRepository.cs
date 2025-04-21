using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface IServiceListingRepository
    {
        public Task<List<ServiceListing>> GetAllServices();
        public Task<ServiceListing?> GetService(int serviceId);
        public Task<List<ServiceListing>> GetMyServices(int profileId);
        public Task<ServiceListing> CreateService(ServiceListing service);
        public Task UpdateService(ServiceListing existingService, ServiceListing service);
        public Task DeleteService(int serviceId);
    }
}
