﻿using Microsoft.EntityFrameworkCore.Update.Internal;
using SkillTrade.Dtos.Create;
using SkillTrade.Dtos.ToClient;
using SkillTrade.Dtos.Update;
using SkillTrade.Entities;

namespace SkillTrade.Mapping
{
    public static class ProfileMapping
    {
        public static ProfileDto ToProfileDto(this Profile profile)
        {
            return new ProfileDto
            {
                Id = profile.Id,
                Name = profile.Name,
                LastName = profile.LastName,
                ServiceList = profile.ServiceList,
                Bookings = profile.Bookings,
            };
        }

        public static Profile ToProfileEntity(this CreateProfileDto profile)
        {
            return new Profile
            {
                Name = profile.Name,
                LastName = profile.LastName
            };
        }

        public static Profile ToProfileEntity(this UpdateProfileDto profile)
        {
            return new Profile
            {
                Name = profile.Name,
                LastName = profile.LastName
            };
        }
    }
}
