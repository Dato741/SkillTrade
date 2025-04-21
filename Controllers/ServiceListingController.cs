using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;
using SkillTrade.Extensions;
using SkillTrade.Interfaces;
using SkillTrade.Mapping;

namespace SkillTrade.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServiceListingController : ControllerBase
    {
        private readonly IServiceListingRepository _serviceListingRepo;
        private readonly IProfileRepository _profileRepo;
        private string Guid => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public ServiceListingController(IServiceListingRepository serviceListingRepository, IProfileRepository profileRepository, ICategoryRepository categoryRepopository)
        {
            _serviceListingRepo = serviceListingRepository;
            _profileRepo = profileRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            List<ServiceListing> services = await _serviceListingRepo.GetAllServices();

            List<ServiceListingDto> servicesDto = services.Select(s => s.ToServiceListingDto()).ToList();

            return Ok(servicesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            ServiceListing? service = await _serviceListingRepo.GetService(id);

            if (service == null) return NotFound("Service not found");

            return Ok(service.ToServiceListingDto());
        }

        [HttpGet("myservices")]
        [Authorize]
        public async Task<IActionResult> GetMyServices()
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            List<ServiceListing> services = await _serviceListingRepo.GetMyServices(profileId);
            List<ServiceListingDto> servicesDto = services.Select(s => s.ToServiceListingDto()).ToList();

            return Ok(servicesDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceListingDto serviceListingDto)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            ServiceListing service = serviceListingDto.ToServiceListingEntity();
            service.ProfileId = profileId;
            service.ServicePostedBy = User.GetUsername()!;

            await _serviceListingRepo.CreateService(service);

            return CreatedAtAction(nameof(GetServiceById), new {id = service.Id}, service.ToServiceListingDto());
        }

        [HttpPut("{serviceId}")]
        [Authorize]
        public async Task<IActionResult> UpdateService(int serviceId, [FromBody] UpdateServiceListingDto updateServiceListingDto)
        {
            int profileId = await _profileRepo.GetCurrUserProfileId(Guid);

            ServiceListing? existingService = await _serviceListingRepo.GetService(serviceId);
            if (existingService == null) return NotFound("Service not found");

            if (existingService.ProfileId !=  profileId) return Unauthorized("Listed service doesn't belong to current user");

            ServiceListing updatedService = updateServiceListingDto.ToServiceListingEntity();
            updatedService.ProfileId = profileId;
            updatedService.Id = existingService.Id;
            updatedService.ServicePostedBy = existingService.ServicePostedBy;

            await _serviceListingRepo.UpdateService(existingService, updatedService);

            return NoContent();
        }

        [HttpDelete("{serviceId}")]
        [Authorize]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            await _serviceListingRepo.DeleteService(serviceId);

            return NoContent();

            // needs correction to delete only authorized users services
        }
    }
}
