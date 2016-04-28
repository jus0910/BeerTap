using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Data;
using BeerTap.Data.Entities;

namespace BeerTap.Services
{
    public static class OfficeHelper
    {
        public static Office GetOffice(int id)
        {
            using (var db = new DataContext())
            {
                return db.Offices.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
