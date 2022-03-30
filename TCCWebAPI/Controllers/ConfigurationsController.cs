using Microsoft.AspNetCore.Mvc;
using TCCBusiness.Interfaces;
using TCCDomain.ViewModels;

namespace TCCWebAPI.Controllers
{
    [Controller]
    [Route("api/")]
    public class ConfigurationsController : Controller
    {
        private readonly IConfigurationsService _service;

        public ConfigurationsController(IConfigurationsService service)
        {
            _service = service;
        }

        [HttpPut("updateConfigurations")]
        public async Task PutConfigurations([FromBody] ConfigurationsViewModel configsVM)
        {
            await _service.UpdateConfigurations(configsVM);
        }
    }
}
