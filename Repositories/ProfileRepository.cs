﻿using Microsoft.EntityFrameworkCore;
using SkillTrade.Data;
using SkillTrade.Entities;
using SkillTrade.Interfaces;

namespace SkillTrade.Repositories
{
    public class ProfileRepository : IProfileRepository
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
            Profile? profile = await _context.Profiles
                                                .Where(p => p.Id == id)
                                                .Include(p => p.ServiceList)
                                                .FirstOrDefaultAsync();

            return profile;
        }

        public async Task<Profile> GetCurrentUserProfile(string guid)
        {
            return (await _context.Profiles
                                        .Where(p => p.UserId == guid)
                                        .Include(p => p.ServiceList)
                                        .Include(p => p.Bookings)
                                        .FirstOrDefaultAsync()
                                        )!;
        }

        public async Task<int> GetCurrUserProfileId(string guid)
        {
            Profile profile = (await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == guid))!;

            return profile.Id;
        }

        public async Task<Profile> CreateProfileAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            return profile;
        }
        public async Task UpdateProfileAsync(Profile currentProfile, Profile updatedProfile)
        {
            _context.Profiles.Entry(currentProfile).CurrentValues.SetValues(updatedProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfileAsync(int id)
        {
           await _context.Profiles.Where(p => p.Id == id).ExecuteDeleteAsync();
        }
    }
}
