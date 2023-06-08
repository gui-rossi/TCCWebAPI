using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCBusiness.Interfaces
{
    public interface IConfigService
    {
        Task ChangeConfigAsync(ConfigEntity config);
        Task<IEnumerable<ConfigEntity>> FetchConfigAsync();

    }
}
