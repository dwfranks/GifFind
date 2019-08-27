using GifFind.API.Entities;
using GifFind.API.Models.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GifFind.API.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._configuration = configuration;
        }
        [HttpPost(Name ="CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null)
            {
                return BadRequest();
            }

            var authResult = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!authResult.Succeeded)
            {
                return BadRequest();
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Tokens:Issuer"],
                _configuration["Tokens:Audience"],
                claims.ToArray(),
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            var tokenPackage = new
            {
                user = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                },
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };

            return Created("", tokenPackage);
        }
    }
}