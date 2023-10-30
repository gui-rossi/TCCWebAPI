using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;
using TCCDomain.ViewModels;

namespace TCCBusiness.Interfaces
{
    public interface IConfigService
    {
        Task ChangeConfigAsync(IEnumerable<ConfigViewModel> config);
        Task<IEnumerable<ConfigEntity>> FetchConfigAsync();

    }
}
