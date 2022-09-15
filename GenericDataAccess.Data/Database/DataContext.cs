using GenericDataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataAccess.Data.Database
{
    public class DataContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "data.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Brad Pitt"},
                new Customer { Id = 2, Name = "Tom Cruise" },
                new Customer { Id = 3, Name = "Tom Hanks" },
                new Customer { Id = 4, Name = "Matt Damon" });
        }
    }
}
