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
            var gps = infos.Where(i => i.Name == "GPS").FirstOrDefault();
            var battery = infos.Where(i => i.Name == "Battery").FirstOrDefault();
            await _hubContext.Clients.All.SendAsync("ReceiveInfos", gps, battery);
        }
    }
}
