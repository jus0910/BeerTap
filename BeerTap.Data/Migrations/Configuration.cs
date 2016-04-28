using System.Collections.Generic;
using BeerTap.Data.Entities;

namespace BeerTap.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerTap.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BeerTap.Data.DataContext context)
        {
            List<Office> offices = new List<Office>()
            {
                new Office(1, "Vancouver"),
                new Office(2, "Regina"),
                new Office(3, "Winnipeg"),
                new Office(4, "Davidson"),
            };

            List<Keg> kegs = new List<Keg>()
            {
                new Keg(1, "Lager", 1000, 100),
                new Keg(2, "Stout", 2500, 200),
                new Keg(3, "Wheat", 1200, 100),
                new Keg(4, "Malt", 1800, 100)
            };

            List<Tap> taps = new List<Tap>()
            {
                new Tap(1, 1, 2, 2000),
                new Tap(2, 2, 1, 1000),
                new Tap(3, 3, 2, 2500),
                new Tap(4, 4, 3, 1200),
                new Tap(5, 1, 4, 1800),
                new Tap(6, 2, 2, 2500),
            };

            context.Offices.AddOrUpdate(x => x.Id, offices.ToArray());
            context.Kegs.AddOrUpdate(x => x.Id, kegs.ToArray());
            context.Taps.AddOrUpdate(x => x.Id, taps.ToArray());
        }
    }
}
