using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    public class EventService : IEventService
    {
        private readonly IChatHub _chatHub;
        private readonly IGenericRepository<EventLogEntity> _repository;

        public EventService(IChatHub chatHub, IGenericRepository<EventLogEntity> repository)
        {
            _chatHub = chatHub;
            _repository = repository;
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

        public async Task<IEnumerable<EventLogEntity>> GetHistory()
        {
            return await _repository.SelectAllAsync();
        }
    }
}
