using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCRepositories.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserHistoryEntity> UserHistory { get; set; }
        public DbSet<RecordingTimeEntity> RecordingTime { get; set; }
        public DbSet<DeviceLocationEntity> DeviceLocation { get; set; }
        public DbSet<ConfigurationsEntity> Configurations { get; set; }
        public DbSet<ActionCategoryEntity> ActionCategory { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
