using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityProvMileage.Extensions
{
  public static class IDbConnectionExtension
  {
    public static System.Data.Common.DbCommand CreateCommand(this System.Data.Common.DbConnection dbConnection, String commandText)
    {
      System.Data.Common.DbCommand dbCommand = dbConnection.CreateCommand();
      dbCommand.CommandText = commandText;

      return dbCommand;
    }
    public static System.Data.Common.DbCommand CreateCommand(this System.Data.Common.DbConnection dbConnection, String commandText, System.Data.CommandType commandType)
    {
      System.Data.Common.DbCommand dbCommand = dbConnection.CreateCommand();
      dbCommand.CommandText = commandText;
      dbCommand.CommandType = commandType;

      return dbCommand;
    }
  }
}
