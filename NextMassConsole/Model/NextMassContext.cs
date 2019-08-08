using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            JsonTools jsonTools = new JsonTools();
            ConfigFile configuration = jsonTools.ReadFile<ConfigFile>("config.json");
            SqlConnectionStringBuilder sBuilder = new SqlConnectionStringBuilder();
            sBuilder.DataSource = configuration.BaseConnectionString;
            sBuilder.InitialCatalog = configuration.InitialCatalog;
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

            builder.Entity<Church>()
                .OwnsMany(c => (List<MassTime>)c.MassTimes);

            builder.Entity<MassTime>()
                .HasOne(mt => (Church)mt.Church)
                .WithMany(c => (List<MassTime>)c.MassTimes)
                .HasForeignKey(mt => mt.ChurchId);

            builder.Entity<Church>()
                .OwnsOne(c => (Location)c.Coordinates);
        }
    }
}
