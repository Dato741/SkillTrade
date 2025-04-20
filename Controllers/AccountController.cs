using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SkillTrade.Dtos.Account;
using SkillTrade.Entities;
using SkillTrade.Identity;
using SkillTrade.Interfaces;

namespace SkillTrade.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly IProfileRepository _profileRepo;

        public AccountController(UserManager<UserIdentity> userManager, ITokenService tokenService, SignInManager<UserIdentity> signInManager, IProfileRepository profileRepository)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _profileRepo = profileRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                UserIdentity appUser = new UserIdentity
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "user");

                    if (roleResult.Succeeded)
                    {
                        Profile profile = new Profile
                        {
                            Name = registerDto.Name,
                            LastName = registerDto.LastName,
                            UserId = appUser.Id
                        };

                        await _profileRepo.CreateProfileAsync(profile);

                        return Ok(new NewUserDto
                        {
                            Username = appUser.UserName,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            UserIdentity? user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user == null) return Unauthorized("Incorrect username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Incorrect password");

            NewUserDto userDto = new NewUserDto
            {
                Username = user.UserName!,
                Email = user.Email!,
                Token = _tokenService.CreateToken(user)
            };

            return Ok(userDto);
        }
    }
}
