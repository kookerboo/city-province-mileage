using System;

namespace CityProvMileage.Extensions
{
  public static class DataReaderExtensions
  {
    /// <summary>
    /// Determines whether this [dataReader] specified [name] field is set to DBNull
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Boolean IsDBNull(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.IsDBNull(dataReader.GetOrdinal(name));
    }


    /// <summary>
    /// Gets the Boolean value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Boolean GetBoolean(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.GetBoolean(dataReader.GetOrdinal(name));
    }
    /// <summary>
    /// Gets the Boolean value from this [dataReader] specified [name] field or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Boolean GetBoolean(this System.Data.IDataReader dataReader, String name, Boolean defaultValue)
    {
      return GetBoolean(dataReader, dataReader.GetOrdinal(name), defaultValue);
    }

    /// <summary>
    /// Gets the Boolean value from this [dataReader] specified [name] field the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Boolean GetBoolean(this System.Data.IDataReader dataReader, Int32 index, Boolean defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetBoolean(index);
    }

    /// <summary>
    /// Gets the Double value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Double GetDouble(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.GetDouble(dataReader.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the Double value from this [dataReader] specified [name] field or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Double GetDouble(this System.Data.IDataReader dataReader, String name, Double defaultValue)
    {
      return GetDouble(dataReader, dataReader.GetOrdinal(name), defaultValue);

    }

    /// <summary>
    /// Gets the Double value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Double GetDouble(this System.Data.IDataReader dataReader, Int32 index, Double defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;

      return dataReader.GetDouble(index);

    }

    /// <summary>
    /// Gets the Float value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Single GetFloat(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.GetFloat(dataReader.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the Float value from this [dataReader] specified [name] field or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Single GetFloat(this System.Data.IDataReader dataReader, String name, Single defaultValue)
    {
      return GetFloat(dataReader, dataReader.GetOrdinal(name), default(Single));

    }

    /// <summary>
    /// Gets the Float value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Single GetFloat(this System.Data.IDataReader dataReader, Int32 index, Single defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;

      return dataReader.GetFloat(index);

    }




    /// <summary>
    /// Gets the Boolean value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Boolean? GetNullableBoolean(this System.Data.IDataReader dataReader, String name)
    {
      return GetNullableBoolean(dataReader, dataReader.GetOrdinal(name), null);
    }
    /// <summary>
    /// Gets the Boolean value from this [dataReader] from the field at [index]
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Boolean? GetNullableBoolean(this System.Data.IDataReader dataReader, Int32 index)
    {
      return GetNullableBoolean(dataReader, index, null);
    }
    /// <summary>
    /// Gets the Boolean value from this [dataReader] specified [name] field or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="Name"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Boolean? GetNullableBoolean(this System.Data.IDataReader dataReader, String name, Boolean? defaultValue)
    {
      return GetNullableBoolean(dataReader, dataReader.GetOrdinal(name), defaultValue);
    }
    /// <summary>
    /// Gets the Boolean value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Boolean? GetNullableBoolean(this System.Data.IDataReader dataReader, Int32 index, Boolean? defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetBoolean(index);
    }
    /// <summary>
    /// Gets the string value from this [dataReader] from the specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static String GetString(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.GetString(dataReader.GetOrdinal(name));
    }
    /// <summary>
    /// Gets the string value from this [dataReader] from the specified [name] field or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static String GetString(this System.Data.IDataReader dataReader, String name, String defaultValue)
    {
      return GetString(dataReader, dataReader.GetOrdinal(name), defaultValue);
    }
    /// <summary>
    /// Gets the string value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static String GetString(this System.Data.IDataReader dataReader, Int32 index, String defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetString(index);
    }


    /// <summary>
    /// Gets the 32-bit signed integer value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Int32 GetInt32(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.GetInt32(dataReader.GetOrdinal(name));
    }

    public static Int32 GetInt32(this System.Data.IDataReader dataReader, String name, Int32 defaultValue)
    {
      if (dataReader.IsDBNull(dataReader.GetOrdinal(name)))
        return defaultValue;
      else
        return dataReader.GetInt32(dataReader.GetOrdinal(name));
    }

    /// <summary>
    /// Gets the 32-bit signed integer value from this [dataReader] specified [name] field the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Int32 GetInt32(this System.Data.IDataReader dataReader, Int32 index, Int32 defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetInt32(index);
    }

    /// <summary>
    /// Gets the 32-bit signed integer value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Int32? GetNullableInt32(this System.Data.IDataReader dataReader, String name)
    {
      return GetNullableInt32(dataReader, dataReader.GetOrdinal(name), null);
    }
    /// <summary>
    /// Gets the 32-bit signed integer value from this [dataReader] from the field at [index]
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Int32? GetNullableInt32(this System.Data.IDataReader dataReader, Int32 index)
    {
      return GetNullableInt32(dataReader, index, null);
    }
    /// <summary>
    /// Gets the 32-bit signed integer value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Int32? GetNullableInt32(this System.Data.IDataReader dataReader, Int32 index, Int32? defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetInt32(index);
    }


    /// <summary>
    /// Gets the date and time data value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static DateTime GetDateTime(this System.Data.IDataReader dataReader, String name)
    {
      return dataReader.GetDateTime(dataReader.GetOrdinal(name));
    }

    public static DateTime GetDateTime(this System.Data.IDataReader dataReader, String name, DateTime defaultValue)
    {
      return GetDateTime(dataReader, dataReader.GetOrdinal(name), defaultValue);
    }

    public static DateTime GetDateTime(this System.Data.IDataReader dataReader, Int32 index, DateTime defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetDateTime(index);
    }

    /// <summary>
    /// Gets the nullable date and time data value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static DateTime? GetNullableDateTime(this System.Data.IDataReader dataReader, String name)
    {
      return GetNullableDateTime(dataReader, dataReader.GetOrdinal(name), null);
    }
    /// <summary>
    /// Gets the nullable date and time data value from this [dataReader] from the field at [index]
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static DateTime? GetNullableDateTime(this System.Data.IDataReader dataReader, Int32 index)
    {
      return GetNullableDateTime(dataReader, index, null);
    }
    /// <summary>
    /// Gets the nullable date and time data value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static DateTime? GetNullableDateTime(this System.Data.IDataReader dataReader, Int32 index, DateTime? defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetDateTime(index);
    }

    /// <summary>
    /// Gets the nullable date and time data value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Double? GetNullableDouble(this System.Data.IDataReader dataReader, String name)
    {
      return GetNullableDouble(dataReader, dataReader.GetOrdinal(name), null);
    }
    /// <summary>
    /// Gets the nullable date and time data value from this [dataReader] from the field at [index]
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Double? GetNullableDouble(this System.Data.IDataReader dataReader, Int32 index)
    {
      return GetNullableDouble(dataReader, index, null);
    }
    /// <summary>
    /// Gets the nullable date and time data value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Double? GetNullableDouble(this System.Data.IDataReader dataReader, Int32 index, Double? defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetDouble(index);
    }

    /// <summary>
    /// Gets the 16-bit signed integer value from this [dataReader] specified [name] field
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Int16? GetNullableInt16(this System.Data.IDataReader dataReader, String name)
    {
      return GetNullableInt16(dataReader, dataReader.GetOrdinal(name), null);
    }
    /// <summary>
    /// Gets the 16-bit signed integer value from this [dataReader] from the field at [index]
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static Int16? GetNullableInt16(this System.Data.IDataReader dataReader, Int32 index)
    {
      return GetNullableInt16(dataReader, index, null);
    }
    /// <summary>
    /// Gets the 32-bit signed integer value from this [dataReader] from the field at [index] or the [defaultValue] if the field is null
    /// </summary>
    /// <param name="dataReader"></param>
    /// <param name="index"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static Int16? GetNullableInt16(this System.Data.IDataReader dataReader, Int32 index, Int16? defaultValue)
    {
      if (dataReader.IsDBNull(index))
        return defaultValue;
      else
        return dataReader.GetInt16(index);
    }
  }
}
