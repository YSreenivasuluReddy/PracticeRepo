using HttpClientEx1.Interfaces;
using HttpClientEx1.Models;
using HttpClientEx1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUserDetails")]
        public IActionResult getUserDetails()
        {
            //here i am get the details from service
            var details = _userService.getUserDetails().ToList();
            //here i am returing the details.
            return Ok(details);
        }

        [HttpGet]
        [Route("GetUserDetailsById")]
        public IActionResult getUserDetailsById(int id)
        {
            var detailsById = _userService.getUserById(id);

            return Ok(detailsById);
        }

        [HttpPost]
        [Route("AddUserDetails")]
        public IActionResult addUserDetails(User user)
        {
            var newUser = _userService.AddNewUser(user);

            return Ok(newUser);
        }
    }
}
