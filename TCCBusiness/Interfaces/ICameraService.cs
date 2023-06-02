using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.ViewModels;

namespace TCCBusiness.Interfaces
{
    public interface ICameraService
    {
        Task AddStatusAsync(CameraVM camera);
        Task<IEnumerable<CameraVM>> FetchStatusAsync();

    }
}
