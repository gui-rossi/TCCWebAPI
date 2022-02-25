using Microsoft.AspNetCore.Mvc;
using TCCBusiness.Interfaces;

namespace TCCWebAPI.Controllers
{
    [Controller]
    [Route("api/{controller}")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("registerUser")]
        string RegisterUser(/*[FromBody]*/string email, string password)
        {
            return _service.AddUserAsync(email, password);
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return NoContent();
        }
    }
}
