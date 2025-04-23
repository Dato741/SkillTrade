using Microsoft.EntityFrameworkCore;
using SkillTrade.Data;
using SkillTrade.Entities;
using SkillTrade.Interfaces;

namespace SkillTrade.Repositories
{
    public class ServiceListingRepository : IServiceListingRepository
    {
        private readonly SkillTradeDbContext _context;

        public ServiceListingRepository(SkillTradeDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceListing>> GetAllServices()
        {
            List<ServiceListing> services = await _context.ServiceListings
                                                        .Include(s => s.Category)
                                                        .Include(s => s.Reviews)
                                                        .ThenInclude(r => r.Profile)
                                                        .ToListAsync();

            return services;
        }
        public async Task<ServiceListing?> GetService(int serviceId)
        {
            return await _context.ServiceListings.Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Id == serviceId);
        }
        public async Task<List<ServiceListing>> GetMyServices(int profileId)
        {
            List<ServiceListing> services = await _context.ServiceListings.Where(s => s.ProfileId == profileId).Include(s => s.Category).ToListAsync();

            return services;
        }
        public async Task<ServiceListing> CreateService(ServiceListing service)
        {
            await _context.ServiceListings.AddAsync(service);
            await _context.SaveChangesAsync();

            await _context.ServiceListings.Entry(service).Reference(s => s.Category).LoadAsync();

            return service;
        }
        public async Task UpdateService(ServiceListing existingService, ServiceListing service)
        {
            _context.ServiceListings.Entry(existingService).CurrentValues.SetValues(service);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteService(int serviceId)
        {
            await _context.ServiceListings.Where(s => s.Id == serviceId).ExecuteDeleteAsync();
        }
    }
}
