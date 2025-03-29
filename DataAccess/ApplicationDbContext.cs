using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Assessment.DbModel;

namespace Test_Assessment.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaxiTrip> TaxiTrips { get; set; }

        public ApplicationDbContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestDb;Trusted_Connection=True;");
        }
    }
}
