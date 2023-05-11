using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;


namespace CityProvMileage.Persistence
{
  class MileageCityRepository
  {
    public static MileageCityRepository Instance { get; set; }

    static MileageCityRepository()
    {
      Instance = new MileageCityRepository();
    }

    public List<Models.MileageCityModel> GetAll()
    {
      List<Models.MileageCityModel> mileageCities = new List<Models.MileageCityModel>();
      string sql = @"select mprov, mcity, mcseq#
                   from database.MileageCity";

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

              Models.MileageCityModel mileageCity = new Models.MileageCityModel()
              {
                Province = dr.GetString(0).Trim(),
                City = dr.GetString(1).Trim(),
                Sequence = dr.GetInt32(2)
              };
              mileageCities.Add(mileageCity);
            }
          }
        }
      }
      return mileageCities;
    }

  }
}


