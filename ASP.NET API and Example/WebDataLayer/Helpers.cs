using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDataLayer
{
    public class Helpers
    {
        public enum ProcNames
        {
            Products,
            ProductGroups,
            ErrorLog
        }

        public enum ProcType
        {
            Select,
            Insert,
            Update,
            Delete
        }

        public static string GetSql(ProcNames name, ProcType type)
        {
            return $"dbo.{name.ToString()}_{type.ToString()}";
        }

        public static double GetFieldAsDouble(string value)
        {
            if (value == string.Empty || value == null)
            {
                return 0;
            }
            return Convert.ToDouble(value);
        }
  
        public static Int32? SqlCheckForNullableInt(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }
        public static Int32 SqlCheckForNullInt(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }
        public static String SqlCheckForNullString(object value)
        {
            if (value == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToString(value);
            }
        }
        public static decimal? SqlCheckForNullableNumeric(object value)
        {
            return SqlCheckForNullableDecimal(value);
        }
        public static decimal? SqlCheckForNullableDecimal(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }
        public static decimal SqlCheckForNullNumeric(object value)
        {
            return SqlCheckForNullDecimal(value);
        }
        public static decimal SqlCheckForNullDecimal(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }
        public static byte SqlCheckForNullByte(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToByte(value);
            }
        }
        public static byte SqlCheckForNullShort(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToByte(value);
            }
        }
        public static float SqlCheckForNullFloat(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(value);
            }
        }
        public static float? SqlCheckForNullableFloat(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return Convert.ToSingle(value);
            }
        }
        public static bool SqlCheckForNullBool(object value)
        {
            if (value == DBNull.Value)
            {
                return false;
            }
            else
            {
                return (bool)value;
            }
        }
        public static bool? SqlCheckForNullableBool(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (bool)value;
            }
        }
        public static DateTime? SqlCheckForNullableDateTime(object value)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            return SqlCheckForNullDate(value);
        }
        public static DateTime SqlCheckForNullDateTime(object value)
        {
            return SqlCheckForNullDate(value);
        }
        public static DateTime SqlCheckForNullDate(object value)
        {
            if (value == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return (DateTime)value;
            }
        }
    }

}