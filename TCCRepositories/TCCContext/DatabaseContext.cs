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
        public DbSet<ConfigEntity> Config { get; set; }
        public DbSet<EventLogEntity> EventLog { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigEntity>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<EventLogEntity>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
