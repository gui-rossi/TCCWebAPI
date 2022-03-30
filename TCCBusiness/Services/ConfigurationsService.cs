using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCDomain.ViewModels;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    internal class ConfigurationsService : IConfigurationsService
    {
        private readonly IConfigurationsRepository _repository;
        public ConfigurationsService(IConfigurationsRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateConfigurations(ConfigurationsViewModel configsVM)
        {
            if (configsVM is null) throw new ArgumentNullException("Null Configurations ViewModel");

            ConfigurationsEntity entity = await _repository.FindAsync(configsVM.id);

            if (entity is null) throw new NullReferenceException("Null Configurations Entity");

            entity.IsLampOn = configsVM.isLampOn;
            entity.Receive_Notifications = configsVM.receive_notifications;
            entity.Battery_Percentage = configsVM.battery_percentage;

            _repository.Update(entity);

            await _repository.SaveChangesAsync();
        }
    }
}
