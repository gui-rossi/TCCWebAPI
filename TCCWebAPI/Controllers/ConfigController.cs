using Microsoft.AspNetCore.Mvc;
using TCCBusiness.Interfaces;
using TCCDomain.Entities;

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

        [HttpGet("IsApiUp")]
        public bool IsApiUp()
        {
            return true;
        }

        [HttpPut("ChangeConfig")]
        public async Task ModifyConfig([FromBody] ConfigEntity config)
        {
            await _service.ChangeConfigAsync(config);
        }

        [HttpGet("FetchConfigs")]
        public async Task<IEnumerable<ConfigEntity>> GetConfigs()
        {
            var rval = await _service.FetchConfigAsync();

            return rval;
        }
    }
}
