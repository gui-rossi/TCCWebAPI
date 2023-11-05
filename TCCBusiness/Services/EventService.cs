using Microsoft.AspNetCore.SignalR;
using System.Buffers.Text;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    public class EventService : IEventService
    {
        private readonly IChatHub _chatHub;
        private readonly IGenericRepository<EventLogEntity> _repository;
        private readonly IHubContext<ChatHub> _hubContext;


        public EventService(IChatHub chatHub, IGenericRepository<EventLogEntity> repository, IHubContext<ChatHub> hubContext)
        {
            _chatHub = chatHub;
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task Save(IEnumerable<EventLogEntity> eventLogs)
        {
            _repository.Insert(eventLogs);
            await _repository.SaveChangesAsync();
        }

        public async Task FetchImageAsync() 
        {
            await _hubContext.Clients.All.SendAsync("ImageRequest");
        }

        public async Task FetchInfosAsync()
        {
            await _hubContext.Clients.All.SendAsync("InfoRequest");
        }

        public async Task<IEnumerable<EventLogEntity>> GetHistory()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task SendImageAsync(string base64Img)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveImage", base64Img);
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


            await _hubContext.Clients.All.SendAsync("ReceiveInfos", gps, battery);
        }

        public async Task NotifyTruckAsync(string base64TruckImg)
        {
            await _hubContext.Clients.All.SendAsync("NotifyTruck", base64TruckImg);
        }

        public async Task NotifyPersonAsync(string base64PersonImg)
        {
            await _hubContext.Clients.All.SendAsync("NotifyPerson", base64PersonImg);
        }

        public async Task NotifyCameraObstructionAsync(string base64Img)
        {
            await _hubContext.Clients.All.SendAsync("NotifyCameraObstruction", base64Img);
        }

        public async Task NotifyPowerLossAsync()
        {
            await _hubContext.Clients.All.SendAsync("NotifyPowerLoss");
        }

        public async Task NotifyFullMemoryAsync()
        {
            await _hubContext.Clients.All.SendAsync("NotifyFullMemory");
        }

        public async Task NotifyGPSMovementAsync()
        {
            await _hubContext.Clients.All.SendAsync("NotifyGPSMovement");
        }
    }
}
