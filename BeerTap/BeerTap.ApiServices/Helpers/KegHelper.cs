using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Data;
using BeerTap.Model;

namespace BeerTap.ApiServices.Helpers
{
    public static class KegHelper
    {
        public static Keg GetById(int id)
        {
            using (var db = new DataContext())
            {
                var keg = db.Kegs.FirstOrDefault(x => x.Id == id);
                return AutoMapper.Mapper.Map<Keg>(keg);
            }
        }

        public static IEnumerable<Keg> GetAll()
        {
            using (var db = new DataContext())
            {
                var result = db.Kegs.ToList();
                return AutoMapper.Mapper.Map<List<Keg>>(result);
            }
        }
    }
}
