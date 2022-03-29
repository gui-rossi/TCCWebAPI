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
    }
}
