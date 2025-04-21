using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface IProfileRepository
    {
        public Task<List<Profile>> GetAllProfilesAsync();
        public Task<Profile?> GetProfileByIdAsync(int id);
        public Task<Profile> GetCurrentUserProfile(string guid);
        public Task<int> GetCurrUserProfileId(string guid);
        public Task<Profile> CreateProfileAsync(Profile profile);
        public Task UpdateProfileAsync(Profile currentProfile, Profile updatedProfile);
        public Task DeleteProfileAsync(int id);
    }
}
