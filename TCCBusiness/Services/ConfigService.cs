using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    internal class ConfigService : IConfigService
    {
        private readonly IGenericRepository<ConfigEntity> _repository;
        private readonly IHubContext<ChatHub> _hubContext;

        public ConfigService(IGenericRepository<ConfigEntity> repository, IHubContext<ChatHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task ChangeConfigAsync(IEnumerable<ConfigEntity> config)
        {
            var entities = await _repository.SelectAllAsync();

            entities = config;

            _repository.Update(entities);

            await _repository.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ConfigChanges", config);
        }

        public async Task<IEnumerable<ConfigEntity>> FetchConfigAsync()
        {
            var entities = await _repository.SelectAllAsync();

            return entities;
        }
    }
}
