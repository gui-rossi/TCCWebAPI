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

        public ConfigService(IGenericRepository<ConfigEntity> repository)
        {
            _repository = repository;
        }

        public Task ChangeConfigAsync(ConfigEntity config)
        {
            _repository.Update(config);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ConfigEntity>> FetchConfigAsync()
        {
            var entities = await _repository.SelectAllAsync();

            return entities;
        }
    }
}
