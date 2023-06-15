using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCBusiness
{
    public class ChatHub : Hub, IChatHub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        //IMPLEMENTAR NA RASP
        public async Task SendConfigs(IEnumerable<ConfigEntity> config)
        {
            await Clients.All.SendAsync("SendConfigs", config);
        }

        //IMPLEMENTAR NA RASP
        public async Task RequestImageToRaspberry()
        {
            await Clients.All.SendAsync("RequestImage");
        }

        public async Task SendImageToUI(string base64)
        {
            await Clients.Others.SendAsync("ReceiveImage", base64);
        }

        //IMPLEMENTAR NA RASP
        public async Task RequestInfosToRaspberry()
        {
            await Clients.All.SendAsync("ReceiveInfos");
        }

        public async Task SendInfosToUI(string gps, string battery)
        {
            await Clients.Others.SendAsync("ReceiveInfos", gps, battery);
        }
    }
}
