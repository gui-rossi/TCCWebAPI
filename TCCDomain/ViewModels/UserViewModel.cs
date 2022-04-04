using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCDomain.ViewModels
{
    public class UserViewModel
    {
        public Guid id;

        public string email;

        public string password;

        public string? name;

        public string? cel;

        public int? worker_count;

        //ConfigurationsViewModel configurations;

        public UserViewModel(Guid Id, string Email, string Password, string? Name, string? Cel, int? Worker_Count
            /*,ConfigurationsViewModel Configurations*/)
        {
            id = Id;
            email = Email;
            password = Password;
            name = Name;
            cel = Cel;
            worker_count = Worker_Count;
            //configurations = Configurations;
        }
    }
}
