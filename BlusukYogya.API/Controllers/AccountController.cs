using BlusukYogya.BLL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using BlusukYogya.BLL.Helpers;
using Microsoft.Extensions.Options;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserBLL _user;
        public AccountController(IOptions<AppSettings> appSettings, IUserBLL userBLL)
        {
            _appSettings = appSettings.Value;
            _user = userBLL;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loginData = await _user.Login(loginDTO.Username, loginDTO.Password);
            var user = await _user.GetByUsername(loginDTO.Username);
            var userWithRole = await _user.GetUserWithRoles(user.UserId);
            if (loginData != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, loginDTO.Username));
                foreach (var role in userWithRole.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new UserWithTokenDTO
                {
                    UserId = user.UserId,
                    Username = loginDTO.Username,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUser()
        {
            {
                var result = await _user.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(int userId, string newPassword)
        {
            {
                var result = await _user.ChangePassword(userId, newPassword);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewUser(UserCreateDTO userCreateDTO)
        {
            {
                var result = await _user.Insert(userCreateDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetUserWithRoles")]
        public async Task<IActionResult> GetUserWithRole(int userId)
        {
            {
                var result = await _user.GetUserWithRoles(userId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
