using Microsoft.EntityFrameworkCore;
using SkillTrade.Data;
using SkillTrade.Entities;
using SkillTrade.Interfaces;

namespace SkillTrade.Repositories
{
    public class ProfileRepository : IProfileInterface
    {
        private readonly SkillTradeDbContext _context;

        public ProfileRepository(SkillTradeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Profile>> GetAllProfilesAsync()
        {
            List<Profile> profiles = await _context.Profiles.ToListAsync();

            return profiles;
        }

        public async Task<Profile?> GetProfileByIdAsync(int id)
        {
            Profile? profile = await _context.Profiles.FindAsync(id);

            return profile;
        }

        public async Task CreateProfileAsync(Profile userProfile)
        {
            await _context.Profiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProfileAsync(Profile userProfile, Profile updatedUserProfile)
        {
            _context.Profiles.Entry(userProfile).CurrentValues.SetValues(updatedUserProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfileAsync(int id)
        {
           await _context.Profiles.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}
