using GifFind.API.Entities;
using GifFind.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFind.API.Controllers
{
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public Users(UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            this._userManager = userManager;
            this._categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> NewUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (user == null)
            {
                return BadRequest();
            }

            var foundAppUser = await _userManager.FindByNameAsync(user.UserName);

            if (foundAppUser != null)
            {
                var message = $"{ user.UserName} already exists";

                return Conflict(message);
            }

            var newUser = new AppUser()
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var identityResult = await _userManager.CreateAsync(newUser, user.Password);

            if (!identityResult.Succeeded)
            {
                return StatusCode(500, identityResult.Errors);
            }

            var newAppUser = await _userManager.FindByNameAsync(user.UserName);

            var defaultCategory = new Category()
            {
                CategoryName = "Default",
                UserID = newAppUser.Id
            };

            await _categoryService.CreateCategoryAsync(defaultCategory);

            return Ok();
        }
    }
}
