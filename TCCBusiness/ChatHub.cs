using Microsoft.AspNetCore.SignalR;
using TCCDomain.Entities;
using TCCDomain.ViewModels;

namespace TCCBusiness
{
    public class ChatHub : Hub, IChatHub
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatHub(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessage(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        //IMPLEMENTAR NA RASP
        public async Task RequestImageToRaspberry()
        {
            await _hubContext.Clients.All.SendAsync("RequestImage");
        }

        //IMPLEMENTAR NA RASP
        public async Task RequestInfosToRaspberry()
        {
            await _hubContext.Clients.All.SendAsync("RequestInfos");
        }

        //RASP -> UI
        public async Task SendImageToUI(string base64)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveImage", base64);
        }

        //RASP -> UI
        public async Task SendInfosToUI(string gps, string battery, string powerSource)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveInfos", gps, battery, powerSource);
        }

        //UI -> RASP
        public async Task SendChangesToRasp(IEnumerable<ConfigViewModel> configViewModelList)
        {
            await _hubContext.Clients.All.SendAsync("ConfigChanges", configViewModelList);
        }

        public async Task NotifyGPSMovement()
        {
            await _hubContext.Clients.All.SendAsync("NotifyGPSMovement");
        }

        public async Task NotifyPowerLoss()
        {
            await _hubContext.Clients.All.SendAsync("NotifyPowerLoss");
        }

        public async Task NotifyFullMemory()
        {
            await _hubContext.Clients.All.SendAsync("NotifyFullMemory");
        }

        public async Task NotifyCameraObstruction()
        {
            await _hubContext.Clients.All.SendAsync("NotifyCameraObstruction");
        }

        public async Task NotifyPerson(string base64Img)
        {
            await _hubContext.Clients.All.SendAsync("NotifyPerson", base64Img);
        }

        public async Task NotifyTruck(string base64Img)
        {
            await _hubContext.Clients.All.SendAsync("NotifyTruck", base64Img);
        }
    }
}
