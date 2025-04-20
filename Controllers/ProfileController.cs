using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            string username = User.GetUsername()!;
            UserIdentity user = (await _userManager.FindByNameAsync(username))!;
            string guid = user.Id;

            Profile updatedProfile = updateProfileDto.ToProfileEntity();

            await _profileRepo.UpdateProfileAsync(guid, updatedProfile);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            await _profileRepo.DeleteProfileAsync(id);
            return NoContent();
        }
    }
}
