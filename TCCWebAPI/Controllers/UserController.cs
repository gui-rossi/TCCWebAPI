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

        [HttpPost("registerUser/{email}/{password}")]
        public async Task RegisterUser(string email, string password)
        {
            await _service.AddUserAsync(email, password);
        }

        [HttpPut("updateUser")]
        public async Task RegisterUser([FromBody] UserViewModel userVM)
        {
            await _service.UpdateUserAsync(userVM);
        }
    }
}
