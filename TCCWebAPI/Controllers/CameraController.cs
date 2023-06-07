using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TCCBusiness.Interfaces;
using TCCDomain.ViewModels;

namespace TCCWebAPI.Controllers
{
    [Controller]
    [Route("api/{controller}/")]
    public class CameraController : Controller
    {
        private readonly ICameraService _service;

        public CameraController(ICameraService service)
        {
            _service = service;
        }

        [HttpGet("IsApiUp")]
        public bool IsApiUp()
        {
            return true;
        }

        //[HttpPost("AddStatus")]
        //public async Task PostStatus([FromBody] CameraVM camera)
        //{
        //    await _service.AddStatusAsync(camera);
        //}

        //[HttpGet("FetchStatus")]
        //public async Task<IEnumerable<CameraVM>> GetStatus()
        //{
        //    var rval = await _service.FetchStatusAsync();

        //    return rval;
        //}
    }
}
