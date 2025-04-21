using System.Security.Claims;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;
using SkillTrade.Extensions;
using SkillTrade.Identity;
using SkillTrade.Interfaces;
using SkillTrade.Mapping;

namespace SkillTrade.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepo;
        private readonly UserManager<UserIdentity> _userManager;

        public ProfileController(IProfileRepository profile, UserManager<UserIdentity> userManager)
        {
            _profileRepo = profile;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles()
        {
            List<Profile> profiles = await _profileRepo.GetAllProfilesAsync();

            List<ProfileDto> profileDtos = profiles.Select(p => p.ToProfileDto()).ToList();

            return Ok(profileDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(int id)
        {
            Profile? profile = await _profileRepo.GetProfileByIdAsync(id);

            if (profile == null) return NotFound("Profile not found");

            return Ok(profile.ToProfileDto());
        }

        [HttpGet("myprofile")]
        [Authorize]
        public async Task<IActionResult> GetMyProfile()
        {
            string guid = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            Profile profile = await _profileRepo.GetCurrentUserProfile(guid);

            return Ok(profile.ToProfileDto());
        }

        // need correction to be used only by admin
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProfile(CreateProfileDto createProfileDto)
        {
            Profile profileEntity = await _profileRepo.CreateProfileAsync(createProfileDto.ToProfileEntity());

            return CreatedAtAction(nameof(GetProfileById), new { id = profileEntity.Id }, profileEntity.ToProfileDto());
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto updateProfileDto)
        {
            string guid = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            Profile currUserProfile = await _profileRepo.GetCurrentUserProfile(guid);

            Profile updatedProfile = updateProfileDto.ToProfileEntity();
            updatedProfile.Id = currUserProfile.Id;
            updatedProfile.UserId = guid;

            await _profileRepo.UpdateProfileAsync(currUserProfile, updatedProfile);

            return NoContent();
        }

        // needs correction to be used only by admin and instead account deletion should be set up followed with deletion of user profile with all connected services, bookings, reviews
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            await _profileRepo.DeleteProfileAsync(id);
            return NoContent();
        }
    }
}
