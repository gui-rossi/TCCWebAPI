using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCBusiness.Interfaces
{
    public interface IEventService
    {
        /// <summary>
        /// Request a new image to the raspberry by signalR.
        /// </summary>
        /// <returns></returns>
        Task FetchImageAsync();

        /// <summary>
        /// Request infos to the raspberry by signalR.
        /// </summary>
        /// <returns></returns>
        Task FetchInfosAsync();

        /// <summary>
        /// Get event history from database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventLogEntity>> GetHistory();
        Task NotifyCameraObstructionAsync();
        Task NotifyFullMemoryAsync();
        Task NotifyGPSMovementAsync();
        Task NotifyPersonAsync(string base64PersonImg);
        Task NotifyPowerLossAsync();

        /// <summary>
        /// Notify truck detection.
        /// </summary>
        /// <param name="base64TruckImg">Truck image</param>
        /// <returns></returns>
        Task NotifyTruckAsync(string base64TruckImg);

        /// <summary>
        /// Save event logs
        /// </summary>
        /// <param name="eventLogs">logs to save</param>
        /// <returns></returns>
        Task Save(IEnumerable<EventLogEntity> eventLogs);

        /// <summary>
        /// Send the image to the app by signalR.
        /// </summary>
        /// <param name="base64Img">Image in base64</param>
        Task SendImageAsync(string base64Img);

        /// <summary>
        /// Send the infos to the app by signalR.
        /// </summary>
        /// <param name="infos">Infos</param>
        Task SendInfosAsync(IEnumerable<InfoEntity> infos);
    }
}
