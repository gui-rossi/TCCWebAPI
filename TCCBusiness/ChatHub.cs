using Microsoft.AspNetCore.SignalR;
using TCCDomain.Entities;
using TCCDomain.ViewModels;

namespace TCCBusiness
{
    public class ChatHub : Hub, IChatHub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        //IMPLEMENTAR NA RASP
        public async Task RequestImageToRaspberry()
        {
            await Clients.All.SendAsync("RequestImage");
        }

        //IMPLEMENTAR NA RASP
        public async Task RequestInfosToRaspberry()
        {
            await Clients.All.SendAsync("ReceiveInfos");
        }

        //RASP -> UI
        public async Task SendImageToUI(string base64)
        {
            await Clients.Others.SendAsync("ReceiveImage", base64);
        }

        //RASP -> UI
        public async Task SendInfosToUI(string gps, string battery, string powerSource)
        {
            await Clients.Others.SendAsync("ReceiveInfos", gps, battery, powerSource);
        }

        //UI -> RASP
        public async Task SendChangesToRasp(IEnumerable<ConfigViewModel> configViewModelList)
        {
            await Clients.All.SendAsync("ConfigChanges", configViewModelList);
        }

        public async Task NotifyGPSMovement()
        {
            await Clients.All.SendAsync("NotifyGPSMovement");
        }

        public async Task NotifyPowerLoss()
        {
            await Clients.All.SendAsync("NotifyPowerLoss");
        }

        public async Task NotifyFullMemory()
        {
            await Clients.All.SendAsync("NotifyFullMemory");
        }

        public async Task NotifyCameraObstruction(string base64Img)
        {
            await Clients.All.SendAsync("NotifyCameraObstruction", base64Img);
        }

        public async Task NotifyPerson(string base64Img)
        {
            await Clients.All.SendAsync("NotifyPerson", base64Img);
        }

        public async Task NotifyTruck(string base64Img)
        {
            await Clients.All.SendAsync("NotifyTruck", base64Img);
        }
    }
}
