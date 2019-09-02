using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CriticalMass.TagNode.Utility
{
    public static class Obj
    {
        public static string DbToString(this object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        public static int DbToInt32(this object obj)
        {
            if (obj == DBNull.Value || obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public static R Str2Entity<R>(this string obj)
        {
            return JsonConvert.DeserializeObject<R>(obj);
        }


        /// <summary>
        /// 转换int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(this object obj)
        {
            if (obj == null || obj == DBNull.Value||!obj.IsInt())
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 转换Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return "{}";
            }
            else
            {
               return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }

        /// <summary>
        /// json字符串转化为对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<R> Str2List<R>(this string obj) {
            if (string.IsNullOrWhiteSpace(obj))
            {
                return null;
            }
            else {
                return JsonConvert.DeserializeObject<List<R>>(obj);
            }
        }

        /// <summary>
        /// 转换int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long GetLong(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 转换DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime GetDatetime(this object obj)
        {
            if (obj == null || obj == DBNull.Value)    
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(obj);
            }
        }
        /// <summary>
        /// 转换stirng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetString(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 转换stirng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetStringByUnit(this object obj,string unit)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString()+"("+ unit+")";
            }
        }
        /// <summary>
        /// 转换stirng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Double GetDouble(this object obj)
        {
            if (obj == null || obj == DBNull.Value || !obj.IsDouble())
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }
        public static bool IsDouble(this object obj)
        {
            Double i = 0;
            if (Double.TryParse(obj.ToString(), out i))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 转换stirng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Decimal GetDecimal(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }
        /// <summary>
        /// 转换stirng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Decimal GetDecimal(this object obj, Decimal defaultValue)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return defaultValue;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }
        public static bool IsDecimal(this object obj)
        {
            Decimal i = 0;
            if (Decimal.TryParse(obj.ToString(), out i))
            {
                return true;
            }
            return false;
        }
        public static bool IsInt(this object obj)
        {
            if (obj==null)
            {
                return false;
            }
            int i = 0;
            if (int.TryParse(obj.ToString(), out i))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 转换stirng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetBool(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(obj);
            }
        }

    }
}
