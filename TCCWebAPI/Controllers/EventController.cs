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

        [HttpPost("SaveEventLogs")]
        public void SaveEventLogs([FromBody] IEnumerable<EventLogEntity> eventLogs)
        {
            _service.Save(eventLogs);
        }

        [HttpGet("RequestImage")]
        public void RequestImage()
        {
            _service.FetchImageAsync();
        }

        [HttpPost("SendImage")]
        public void SendImage([FromBody] string base64Img)
        {
            _service.SendImageAsync(base64Img);
        }

        [HttpGet("RequestInfos")]
        public void RequestInfos()
        {
            _service.FetchInfosAsync();
        }

        [HttpGet("SendInfos")]
        public void SendInfos([FromBody] IEnumerable<InfoEntity> infos)
        {
            _service.SendInfosAsync(infos);
        }

        [HttpGet("GetHistory")]
        public async Task<IEnumerable<EventLogEntity>> GetHistory()
        {
            return await _service.GetHistory();
        }
    }
}
