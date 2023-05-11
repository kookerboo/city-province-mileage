using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;

namespace CityProvMileage.Persistence
{
  class CityRepository
  {
    public static CityRepository Instance { get; set; }

    static CityRepository()
    {
      Instance = new CityRepository();
    }
    public List<Models.CityModel> GetAll()
    {
      List<Models.CityModel> cities = new List<Models.CityModel>();
      string sql = @"select ctprov, ctcity, ctstpr, ctlgct, ctstct, ctsubr 
                   from database.oscity 
                   where (ctprov between 50 and 68
                     or ctprov = 93)
                   and (ctcity != 0
                   or ctlgct != '')";

      //string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
      using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["connStr"].ToString()))
      {
        connection.Open();
        using (OdbcCommand command = connection.CreateCommand())
        {
          command.CommandText = sql;
          using (OdbcDataReader dr = command.ExecuteReader())
          {
            while (dr.Read())
            {
              Models.CityModel city = new Models.CityModel()
              {
                ProvinceCode = dr.GetInt32(0),
                CityCode = dr.GetInt32(1),
                Province = dr.GetString(2).Trim(),
                LongCityName = dr.GetString(3).Trim(),
                ShortCityName = dr.GetString(4).Trim(),
                SuburbCode = dr.GetInt32(5)
              };
              cities.Add(city);
            }
          }
        }
      }
      return cities;
    }

  }
}

