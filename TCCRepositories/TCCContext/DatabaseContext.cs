using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCRepositories.TCCContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserHistoryEntity> UserHistory { get; set; }
        public DbSet<RecordingTimeEntity> RecordingTime { get; set; }
        public DbSet<DeviceLocationEntity> DeviceLocation { get; set; }
        public DbSet<ConfigurationsEntity> Configurations { get; set; }
        public DbSet<ActionCategoryEntity> ActionCategory { get; set; }
        public DbSet<CameraEntity> Camera { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //ADD CAMERA DATAMODEL

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

            //1:1 relationship between User & Configurations
            modelBuilder.Entity<UserEntity>()
                .HasOne(c => c.Configurations)
                .WithOne(u => u.User)
                .HasForeignKey<ConfigurationsEntity>(c => c.User_Id);

            //1:n relationship between User & UserHistory
            modelBuilder.Entity<UserHistoryEntity>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.User_History)
                .HasForeignKey(uh => uh.User_Id);

            //1:n relationship between User & DeviceLocation
            modelBuilder.Entity<DeviceLocationEntity>()
                .HasOne(dl => dl.User)
                .WithMany(u => u.Device_Locations)
                .HasForeignKey(dl => dl.User_Id);
        }
    }
}
