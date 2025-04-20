using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface IProfileInterface
    {
        public Task<List<Profile>> GetAllProfilesAsync();
        public Task<Profile?> GetProfileByIdAsync(int id);
        public Task CreateProfileAsync(Profile userProfile);
        public Task UpdateProfileAsync(Profile userProfile, Profile updatedUserProfile);
        public Task DeleteProfileAsync(int id);
    }
}
