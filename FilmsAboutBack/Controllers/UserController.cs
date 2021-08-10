using FilmsAboutBack.DataAccess.DTO.Requests;
using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Helpers;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
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
            ) 
        {
            _userService = userService;
            _hostEnvironment = hostEnvironment;
            _refreshTokenValidator = refreshTokenValidator;
            _tokenDecoder = tokenDecoder;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserAsync()
        {
            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];

            int userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _userService.GetUserAsync(userId);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)));
            }

            var response = await _userService.LoginUserAsync(loginData);

            if (response.IsSucceeded) SetCookie(response.Value);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)));
            }

            var response = await _userService.RegisterUserAsync(registerData);

            if (response.IsSucceeded) SetCookie(response.Value);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshAsync()
        {
            Request.Cookies.TryGetValue("refreshToken", out string refreshToken);

            bool ValidationResult = _refreshTokenValidator.Validate(refreshToken);
            if (!ValidationResult) return Unauthorized("Invalid token.");

            var response = await _userService.RefreshAsync(refreshToken);

            if (response.IsSucceeded) SetCookie(response.Value);

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
        }

        [HttpDelete("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LogoutAsync()
        {
            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];

            int userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _userService.LogoutAsync(userId);

            SetCookie(new LoginResponse("", ""));

            ObjectResult objectResult = new ObjectResult(response.IsSucceeded ? response.Value : response.ErrorMessage)
            {
                StatusCode = (int?)response.StatusCode
            };

            return objectResult;
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
