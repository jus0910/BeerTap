using System.Collections.Generic;
using System.Linq;
using BeerTap.Data;
using BeerTap.Model;

namespace BeerTap.ApiServices.Helpers
{
    public static class OfficeHelper
    {
        public static Office GetOffice(int id)
        {
            using (var db = new DataContext())
            {
                var result = db.Offices.FirstOrDefault(x => x.Id == id);
                return AutoMapper.Mapper.Map<Office>(result);
            }
        }

        public static IEnumerable<Office> GetAll()
        {
            using (var db = new DataContext())
            {
                var result = db.Offices.ToList();
                return AutoMapper.Mapper.Map<IEnumerable<Office>>(result);
            }
        }
    }
}
