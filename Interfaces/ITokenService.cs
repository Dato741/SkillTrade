using SkillTrade.Identity;

namespace SkillTrade.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(UserIdentity user);
    }
}
