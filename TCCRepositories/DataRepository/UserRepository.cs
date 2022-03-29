using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;
using TCCRepositories.TCCContext;

namespace TCCRepositories.DataRepository
{
    internal class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) {}

        public async Task<UserEntity> FindByEmailAsync(string email)
        {
            return await _db.User
                    .Include(c => c.Configurations)
                    .Include(d => d.Device_Locations)
                    .Include(uh => uh.User_History)
                    .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
