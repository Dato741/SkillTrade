using System.Security.Claims;

namespace SkillTrade.Extensions
{
    public static class ClaimsExtentions
    {
        public static string? GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.GivenName);
        }
    }
}
