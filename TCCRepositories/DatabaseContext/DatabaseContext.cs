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

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //1:1 relationship between ActionCategory & UserHistory
            modelBuilder.Entity<ActionCategoryEntity>()
                .HasOne(ac => ac.User_History)
                .WithOne(uh => uh.Action_Category)
                .HasForeignKey<UserHistoryEntity>(ac => ac.Category_Id);

            //1:1 relationship between RecordingTime & Configurations
            modelBuilder.Entity<RecordingTimeEntity>()
                .HasOne(c => c.Configurations)
                .WithOne(rt => rt.Recording_Time)
                .HasForeignKey<ConfigurationsEntity>(c => c.Recording_Id);
        }

    }
}
