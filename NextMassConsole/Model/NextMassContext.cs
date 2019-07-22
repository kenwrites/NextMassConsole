using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NextMassConsole.Model
{
    class NextMassContext : DbContext
    {
        DbSet<Church> Churches { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<MassTime> MassTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build SQL Server Connection String
            Config config = new Config();
            ConfigFile configuration = config.ReadConfigFile("config.json");
            SqlConnectionStringBuilder sBuilder = new SqlConnectionStringBuilder();
            sBuilder.DataSource = configuration.BaseConnectionString;
            sBuilder.Password = configuration.Password;
            sBuilder.UserID = configuration.UserName;

            optionsBuilder.UseSqlServer(sBuilder.ConnectionString);
        }
    }
}
