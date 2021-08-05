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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Primitives;

namespace FilmsAboutBack.Controllers
{
    [Route("api/[controller]")]
    public class UserController : CRUDController<User>
    {
        private IUserService _userService;
        private IWebHostEnvironment _hostEnvironment;
        private RefreshTokenValidator _refreshTokenValidator;
        private TokenDecoder _tokenDecoder;

        public UserController(
            IUserService userService,
            IWebHostEnvironment hostEnvironment,
            RefreshTokenValidator refreshTokenValidator,
            TokenDecoder tokenDecoder
            ) : base(userService)
        {
            _userService = userService;
            _hostEnvironment = hostEnvironment;
            _refreshTokenValidator = refreshTokenValidator;
            _tokenDecoder = tokenDecoder;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)));
                }

                var response = await _userService.LoginUserAsync(loginData);

                SetCookie(response);

                return Ok(response);
            }
            catch (ArgumentException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registerData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)));
                }

                var response = await _userService.RegisterUserAsync(registerData);

                SetCookie(response);

                return Ok(response);
            }
            catch (ArgumentException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
            }
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] string refreshToken)
        {
            bool ValidationResult = _refreshTokenValidator.Validate(refreshToken);

            if (!ValidationResult) return Unauthorized("Invalid token.");

            var response = await _userService.RefreshAsync(refreshToken);

            SetCookie(response);

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];

            int userId = _tokenDecoder.getUserIdFromToken(token.ToString());

            bool isTokenDeleted = await _userService.LogoutAsync(userId);

            if (!isTokenDeleted)
            {
                return BadRequest();
            }

            //Response.Cookies.Delete("refreshToken");
            SetCookie(new LoginResponse("", ""));

            return Ok();

        }

        private void SetCookie(LoginResponse response)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddMinutes(Constants.MINUTES_IN_MONTH),
                SameSite = SameSiteMode.None,
                Secure = true,
            };
            Response.Cookies.Append("refreshToken", response.RefreshToken, cookieOptions);
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
