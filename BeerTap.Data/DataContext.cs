using System.Data.Entity;
using BeerTap.Data.Entities;
using BeerTap.Data.Migrations;

namespace BeerTap.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=BeerTapConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>("BeerTapConnectionString"));
        }
        public DbSet<Office> Offices { get; set; }

        public DbSet<Keg> Kegs { get; set; }

        public DbSet<Tap> Taps { get; set; }
    }
}
