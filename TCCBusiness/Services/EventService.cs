using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;

namespace TCCBusiness.Services
{
    public class EventService : IEventService
    {
        private readonly IChatHub _chatHub;

        public EventService(IChatHub chatHub)
        {
            _chatHub = chatHub;
        }

        public void FetchImageAsync() 
        {
            //ENVIA SIGNALR PARA RASP PEGAR FOTO
            _chatHub.RequestImageToRaspberry();
        }

        public void FetchInfosAsync()
        {
            //ENVIA SIGNALR PARA RASP PEGAR INFOS: GPS, BATERIA
            _chatHub.RequestInfosToRaspberry();
        }
    }
}
