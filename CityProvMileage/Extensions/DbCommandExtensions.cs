using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityProvMileage.Extensions
{
  public static class IDbCommandExtensions
  {
    /// <summary>
    /// Adds to this [command] a parameter with the given [name], [dbtype] and [value]
    /// </summary>
    /// <param name="command"></param>
    /// <param name="name"></param>
    /// <param name="dbtype">defaults to DBNull if null</param>
    /// <param name="value"></param>
    public static System.Data.Common.DbParameter AddParameter(this System.Data.Common.DbCommand command, String name, System.Data.DbType dbtype, Object value)
    {
      return AddParameter(command, name, dbtype, value, System.Data.ParameterDirection.Input);
    }
    public static System.Data.Common.DbParameter AddParameter(this System.Data.Common.DbCommand command, String name, System.Data.DbType dbtype, Object value, System.Data.ParameterDirection direction)
    {
      System.Data.Common.DbParameter parameter = command.CreateParameter();
      parameter.ParameterName = name;
      parameter.DbType = dbtype;
      parameter.Value = value ?? DBNull.Value;
      parameter.Direction = direction;

      command.Parameters.Add(parameter);
      return parameter;
    }
    public static System.Data.DataSet ExecuteDataSet(this System.Data.Common.DbCommand command)
    {
      System.Data.DataSet dataSet = new System.Data.DataSet();
      using (System.Data.Common.DbDataReader dataReader = command.ExecuteReader())
      {
        do
        {
          System.Data.DataTable table = new System.Data.DataTable();
          table.Load(dataReader);
          dataSet.Tables.Add(table);
        } while (!dataReader.IsClosed);
      }
      return dataSet;
    }
  }
}
