using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BeerTap.Common;
using BeerTap.Common.Constants;
using BeerTap.Model;
using Dapper;

namespace BeerTap.ApiServices.Helpers
{
    public static class KegHelper
    {
        private static readonly string Conn = ConfigurationManager.ConnectionStrings[BeerTapConstants.ConnectionString].ConnectionString; 
        public static Keg GetById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(Conn))
            {
                dbConnection.Open();
                var keg = dbConnection.Query<Keg>("Select * From Kegs Where Id = @Id", new { Id = id }).FirstOrDefault();
                return keg;
            }
        }

        public static IEnumerable<Keg> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(Conn))
            {
                dbConnection.Open();
                var kegs = dbConnection.Query<Keg>("Select * From Kegs");
                return kegs;
            }
        }
    }
}
