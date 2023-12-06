using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;
using TCCDomain.ViewModels;

namespace TCCBusiness
{
    public interface IChatHub
    {
        Task SendMessage(string user, string message);

        Task RequestImageToRaspberry();

        Task RequestInfosToRaspberry();

        Task SendImageToUI(string base64);

        Task SendChangesToRasp(IEnumerable<ConfigViewModel> configViewModelList);

        Task NotifyGPSMovement();

        Task NotifyPowerLoss();

        Task NotifyFullMemory();

        Task NotifyCameraObstruction();

        Task NotifyPerson(string base64Img);

        Task NotifyTruck(string base64Img);

        Task SendInfosToUI(string gps, string battery, string powerSource);
    }
}
