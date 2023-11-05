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

        //// Methods called by the App:
        
        [HttpGet("GetHistory")]
        public async Task<IEnumerable<EventLogEntity>> GetHistory()
        {
            return await _service.GetHistory();
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

        //// Methods called by the raspberry:

        [HttpPost("SaveEventLogs")]
        public void SaveEventLogs([FromBody] IEnumerable<EventLogEntity> eventLogs)
        {
            _service.Save(eventLogs);
        }

        [HttpPost("SendImage")]
        public void SendImage([FromBody] string base64Img)
        {
            _service.SendImageAsync(base64Img);
        }

        [HttpPost("SendInfos")]
        public void SendInfos([FromBody] IEnumerable<InfoEntity> infos)
        {
            _service.SendInfosAsync(infos);
        }

        [HttpPost("NotifyTruck")]
        public void NotifyTruck([FromBody] string base64TruckImg)
        {
            _service.NotifyTruckAsync(base64TruckImg);
        }

        [HttpPost("NotifyPerson")]
        public void NotifyPerson([FromBody] string base64PersonImg)
        {
            _service.NotifyPersonAsync(base64PersonImg);
        }

        [HttpPost("NotifyCameraObstruction")]
        public void NotifyCameraObstruction([FromBody] string base64Img)
        {
            _service.NotifyCameraObstructionAsync(base64Img);
        }

        [HttpPost("NotifyFullMemory")]
        public void NotifyFullMemory()
        {
            _service.NotifyFullMemoryAsync();
        }

        [HttpPost("NotifyPowerLoss")]
        public void NotifyPowerLoss()
        {
            _service.NotifyPowerLossAsync();
        }

        [HttpPost("NotifyGPSMovement")]
        public void NotifyGPSMovement()
        {
            _service.NotifyGPSMovementAsync();
        }
    }
}
