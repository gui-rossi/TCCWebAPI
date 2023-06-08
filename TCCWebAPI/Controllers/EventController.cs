using Microsoft.AspNetCore.Mvc;
using TCCBusiness.Interfaces;
using TCCBusiness.Services;
using TCCDomain.Entities;

namespace TCCWebAPI.Controllers
{
    [Controller]
    [Route("api/{controller}/")]
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpGet("RequestImage")]
        public void RequestImage()
        {
            _service.FetchImageAsync();
        }

        [HttpGet("RequestInfos")]
        public void RequestInfos()
        {
            _service.FetchInfosAsync();
        }
    }
}
