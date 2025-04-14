using SkillTrade.Identity;

namespace SkillTrade.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(UserIdentity user);
    }
}
