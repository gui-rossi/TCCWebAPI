using Microsoft.AspNetCore.SignalR;
using System.Buffers.Text;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepository<EventLogEntity> _repository;
        private readonly IChatHub _hubContext;


        public EventService(IGenericRepository<EventLogEntity> repository, IChatHub hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task Save(IEnumerable<EventLogEntity> eventLogs)
        {
            _repository.Insert(eventLogs);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventLogEntity>> GetHistory()
        {
            var rval = (await _repository.SelectAllAsync()).OrderByDescending(x => x.TimeStamp);

            return rval;
        }

        public async Task SendImageAsync(string base64Img)
        {
            await _hubContext.SendImageToUI(base64Img);
        }

        public async Task SendInfosAsync(IEnumerable<InfoEntity> infos)
        {
            //// Example Values:
            //// "Timestamp: 03:53:48+00:00| Latitude = -25.429721833333332| Longitude = -49.26172533333333"
            //// "Unavailable"
            var gps = infos.Where(i => i.Name == "GPS").FirstOrDefault();

            //// Example Value:
            //// "59%"
            var battery = infos.Where(i => i.Name == "Battery").FirstOrDefault();

            //// Example Values:
            //// "Battery" or "Outlet"
            var powerSource = infos.Where(i => i.Name == "Power").FirstOrDefault();


            await _hubContext.SendInfosToUI(gps?.Value ?? "", battery?.Value ?? "", powerSource?.Value ?? "");
        }

        public async Task NotifyTruckAsync(string base64TruckImg)
        {
            await _hubContext.NotifyTruck(base64TruckImg);
        }

        public async Task NotifyPersonAsync(string base64PersonImg)
        {
            await _hubContext.NotifyPerson(base64PersonImg);
        }

        public async Task NotifyCameraObstructionAsync()
        {
            await _hubContext.NotifyCameraObstruction();
        }

        public async Task NotifyPowerLossAsync()
        {
            await _hubContext.NotifyPowerLoss();
        }

        public async Task NotifyFullMemoryAsync()
        {
            await _hubContext.NotifyFullMemory();
        }

        public async Task NotifyGPSMovementAsync()
        {
            await _hubContext.NotifyGPSMovement();
        }

        public async Task FetchImageAsync()
        {
            await _hubContext.RequestImageToRaspberry();
        }

        public async Task FetchInfosAsync()
        {
            await _hubContext.RequestInfosToRaspberry();
        }
    }
}
