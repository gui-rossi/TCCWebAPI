using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;

namespace TCCBusiness.Services
{
    internal class UserService : IUserService
    {
        public UserService()
        {

        }

        public string AddUserAsync(string email, string password)
        {
            return "deu boa";
        }
    }
}
