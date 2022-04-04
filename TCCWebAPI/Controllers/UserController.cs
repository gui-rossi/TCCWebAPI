using Microsoft.AspNetCore.Mvc;
using TCCBusiness.Interfaces;
using TCCDomain.ViewModels;

namespace TCCWebAPI.Controllers
{
    [Controller]
    [Route("api/")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("IsApiUp")]
        public bool IsApiUp()
        {
            return true;
        }

        [HttpGet("fetchUser/{email}/{password}")]
        public async Task<UserViewModel> LoginUser(string email, string password)
        {
            return await _service.FetchUserAsync(email, password);
        }

        [HttpPost("registerUser/{email}/{password}")]
        public async Task PostUser(string email, string password)
        {
            await _service.AddUserAsync(email, password);
        }

        [HttpPut("updateUser")]
        public async Task PutUser([FromBody] UserViewModel userVM)
        {
            await _service.UpdateUserAsync(userVM);
        }
    }
}
