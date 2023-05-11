using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;

namespace CityProvMileage.Persistence
{
  class MileageDistanceRepository
  {
    public static MileageDistanceRepository Instance { get; set; }

    static MileageDistanceRepository()
    {
      Instance = new MileageDistanceRepository();
    }
    public List<Models.MileageModel> GetAll()
    {
      List<Models.MileageModel> mileages = new List<Models.MileageModel>();
      string sql = @"select mcity, mprov, mcseq#
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

              Models.MileageModel mileageCity = new Models.MileageModel()
              {
                Province = dr.GetString(0),
                City = dr.GetString(1),
                Sequence = dr.GetInt32(2)
              };
              mileages.Add(mileageCity);

            }
          }
        }
      }
      return mileages;
    }

  }
}

