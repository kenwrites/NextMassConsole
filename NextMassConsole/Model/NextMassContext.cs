using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NextMassConsole.Model
{
    class NextMassContext : DbContext
    {
        public DbSet<Church> Churches { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build SQL Server Connection String
            Config config = new Config();
            ConfigFile configuration = config.ReadConfigFile("config.json");
            SqlConnectionStringBuilder sBuilder = new SqlConnectionStringBuilder();
            sBuilder.DataSource = configuration.BaseConnectionString;
            sBuilder.InitialCatalog = "NextMassConsole";
            sBuilder.Password = configuration.Password;
            sBuilder.UserID = configuration.UserName;

            optionsBuilder.UseSqlServer(sBuilder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Set up the many-to-many relationship between Churches and Users

            builder.Entity<ChurchUser>()
                .HasKey(cu => new { cu.ChurchId, cu.UserId });

            builder.Entity<ChurchUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.FavoriteChurches)
                .HasForeignKey(cu => cu.UserId);

            builder.Entity<ChurchUser>()
                .HasOne(cu => cu.Church)
                .WithMany(c => c.FavoritedBy)
                .HasForeignKey(cu => cu.ChurchId);

            builder.Entity<MassTime>()
                .HasOne(mt => (Church)mt.Church)
                .WithMany(c => c.MassTimes)
                .HasForeignKey(mt => mt.ChurchId);
                
                
            

        }
    }
}
