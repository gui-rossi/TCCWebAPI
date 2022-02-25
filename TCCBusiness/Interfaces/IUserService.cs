using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCBusiness.Interfaces
{
    public interface IUserService
    {
        string AddUserAsync(string email, string password);
    }
}
