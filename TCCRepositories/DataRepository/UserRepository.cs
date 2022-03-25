﻿using System;
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
        public UserRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
