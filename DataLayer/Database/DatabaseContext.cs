using System;
using System.IO;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "A",
                Password = "1234",
                Roles = PsProjAleksandurTenev_501222019_49B.Others.UserRolesEnum.ADMIN,
                Age = 20,
                Expires = new DateTime(2042, 1, 1) 

            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);

           
            modelBuilder.Entity<LogEntry>().Property(e => e.Id).ValueGeneratedOnAdd();
        }

        public DbSet<DatabaseUser> Users { get; set; }

       
        public DbSet<LogEntry> Logs { get; set; }
    }
}
