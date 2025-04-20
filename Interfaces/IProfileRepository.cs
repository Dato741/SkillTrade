using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;

namespace SkillTrade.Interfaces
{
    public interface IProfileRepository
    {
        public Task<List<Profile>> GetAllProfilesAsync();
        public Task<Profile?> GetProfileByIdAsync(int id);
        public Task<Profile> CreateProfileAsync(Profile profile);
        public Task UpdateProfileAsync(string guid, Profile updatedProfile);
        public Task DeleteProfileAsync(int id);
    }
}
