using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Helpers;
using System.Net;

namespace FilmsAboutBack.Controllers
{
    [Route("api/[controller]")]
    public class UserController : CRUDController<User>
    {
        private IUserService _userService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment hostEnvironment) : base(userService)
        {
            _userService = userService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)));
                }

                var response = await _userService.LoginUser(loginData);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.Now.AddMinutes(Constants.MINUTES_IN_MONTH),
                };
                Response.Cookies.Append("refresh_token", response.RefreshToken, cookieOptions);

                return Ok(response);
            }
            catch (ArgumentException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error.Message); ;
            }
        }

        [HttpPost("register")]
        public async Task<LoginResponse> Register([FromBody] LoginRequest loginData)
        {
            var response = await _userService.LoginUser(loginData);
            return response;
        }

        //[HttpPost("add")]
        //public override async Task CreateAsync([FromForm] User user)
        //{
        //    user.Avatar = await SaveImage(user.ImageFile);
        //    await _userService.UpdateAsync(user);
        //}

        //[NonAction]
        //public async Task<string> SaveImage(IFormFile imageFile)
        //{
        //    string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
        //    imageName = imageName + DateTime.Now.ToString("yyMMddssfff") + Path.GetExtension(imageFile.FileName);
        //    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Assets", imageName);
        //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream);
        //    }
        //    return imageName;
        //}
    }
}
