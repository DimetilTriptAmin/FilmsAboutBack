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
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ControllerValidation]
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

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginData)
        {
            var response = await _userService.LoginUserAsync(loginData);

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            else
            {
                SetCookie(response.Value);
                return Ok(response.Value);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registerData)
        {
            var response = await _userService.RegisterUserAsync(registerData);

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            else
            {
                SetCookie(response.Value);
                return Ok(response.Value);
            }
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshAsync()
        {
            Request.Cookies.TryGetValue("refreshToken", out string refreshToken);

            bool ValidationResult = _refreshTokenValidator.Validate(refreshToken);
            if (!ValidationResult) return Unauthorized("Invalid token.");

            var response = await _userService.RefreshAsync(refreshToken);


            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            else
            {
                SetCookie(response.Value);
                return Ok(response.Value);
            }
        }

        [HttpDelete("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LogoutAsync()
        {
            var token = Request.Headers["Authorization"].ToString().Split()[Constants.TOKEN_VALUE_INDEX];

            int userId = _tokenDecoder.getUserIdFromToken(token);

            var response = await _userService.LogoutAsync(userId);

            SetCookie(new LoginResponse("", ""));

            if (!response.IsSucceeded) return BadRequest(response.ErrorMessage);
            return Ok(response.Value);
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
