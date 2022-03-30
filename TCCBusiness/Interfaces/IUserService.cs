using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.ViewModels;

namespace TCCBusiness.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(string email, string password);
        Task UpdateUserAsync(UserViewModel userVM);
        Task<UserViewModel> FetchUserAsync(string email, string password);

    }
}
