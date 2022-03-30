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
    internal class ConfigurationsRepository : GenericRepository<ConfigurationsEntity>, IConfigurationsRepository
    {
        public ConfigurationsRepository(DatabaseContext context) : base(context) {}


    }
}
