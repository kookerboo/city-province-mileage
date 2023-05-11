using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;

namespace CityProvMileage.Persistence
{
  class MileageRepository
  {
    public static MileageRepository Instance { get; set; }

    static MileageRepository()
    {
      Instance = new MileageRepository();
    }

    public List<Models.MileageModel> GetAll()
    {
      List<Models.MileageModel> mileages = new List<Models.MileageModel>();
      string sql = @"select mdfrom, mdto, mdmile, mdkms
                   from database.mgdist";

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
              Models.MileageModel mileage = new Models.MileageModel()
              {
                SequenceFrom = dr.GetInt32(0),
                SequenceTo = dr.GetInt32(1),
                Mile = dr.GetInt32(2),
                Kilometer = dr.GetInt32(3)
              };
              mileages.Add(mileage);
            }
          }
        }
      }
      return mileages;
    }

  }
}

