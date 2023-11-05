using Microsoft.AspNetCore.Mvc;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;
using TCCDomain.ViewModels;

namespace TCCWebAPI.Controllers
{
    [Controller]
    [Route("api/{controller}/")]
    public class ConfigController : Controller
    {
        private readonly IConfigService _service;

        public ConfigController(IConfigService service)
        {
            _service = service;
        }
        //// Methods called by the App:

        [HttpGet("IsApiUp")]
        public bool IsApiUp()
        {
            return true;
        }

        [HttpPut("ChangeConfig")]
        public async Task ModifyConfig([FromBody] IEnumerable<ConfigViewModel> configs)
        {
            await _service.ChangeConfigAsync(configs);
        }

        //// Methods called by the raspberry:

        [HttpGet("FetchConfigs")]
        public async Task<IEnumerable<ConfigEntity>> GetConfigs()
        {
            var rval = await _service.FetchConfigAsync();

            return rval;
        }
    }
}
