using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCBusiness
{
    public interface IChatHub
    {
        Task SendMessage(string user, string message);

        Task SendConfigs(ConfigEntity config);

        Task RequestImageToRaspberry();

        Task RequestInfosToRaspberry();
    }
}
