using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCDomain.ViewModels;
using TCCRepositories.Interfaces;

namespace TCCBusiness.Services
{
    internal class ConfigService : IConfigService
    {
        private readonly IGenericRepository<ConfigEntity> _repository;
        private readonly IChatHub _hubContext;
        private readonly IHubContext<ChatHub> _hubContext2;

        public ConfigService(IGenericRepository<ConfigEntity> repository, IChatHub hubContext, IHubContext<ChatHub> hubContext2)
        {
            _repository = repository;
            _hubContext = hubContext;
            _hubContext2 = hubContext2;
        }

        public async Task ChangeConfigAsync(IEnumerable<ConfigViewModel> configViewModelList)
        {
            var configEntityList = configViewModelList.Select(v => new ConfigEntity
            {
                Id = v.Id,
                ConfigLabel = v.ConfigLabel,
                Active = v.Active,
                StartTime = JsStringToDateTime(v.StartTime),
                EndTime = JsStringToDateTime(v.EndTime)
            });

            var entities = await _repository.SelectAllAsync();

            entities = configEntityList;

            _repository.Update(entities);

            await _repository.SaveChangesAsync();

            await _hubContext.SendChangesToRasp(configViewModelList);
        }

        public async Task<IEnumerable<ConfigEntity>> FetchConfigAsync()
        {
            var entities = await _repository.SelectAllAsync();

            return entities;
        }

        private DateTime JsStringToDateTime(string jsDateTimeString)
        {
            string cleanedJsDateTimeString = RemoveTimeZoneInformation(jsDateTimeString);

            try
            {
                return DateTime.ParseExact(cleanedJsDateTimeString, "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Console.WriteLine("Error converting js datetime string to c# datetime");
                return default(DateTime);
            }
        }

        private string RemoveTimeZoneInformation(string jsDateTimeString)
        {
            int parenIndex = jsDateTimeString.IndexOf("GMT");
            if (parenIndex >= 0)
            {
                jsDateTimeString = jsDateTimeString.Substring(0, parenIndex).Trim();
            }
            return jsDateTimeString;
        }
    }
}
