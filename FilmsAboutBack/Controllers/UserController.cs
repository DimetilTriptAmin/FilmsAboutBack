using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : CRUDController<User>
    {
        private IUserService _userService;

        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

    }
}
