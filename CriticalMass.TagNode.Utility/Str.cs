using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CriticalMass.TagNode.Utility
{
   public static class Str
    {

        public static string ToMd5(this string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString().ToLower();
        }


        public static string IntToHex(this int num) {
            byte[] bt = BitConverter.GetBytes(num);
            string str= ByteToHexStr(bt);
            str = "0000000" + str;
            str=str.Substring(str.Length-8);
            string str1 = str.Substring(0,4);
            string str2 = str.Substring(3);
            string str1_1 = str1.Substring(0,2);
            string str1_2 = str1.Substring(2);
            string str2_1 = str2.Substring(0, 2);
            string str2_2 = str2.Substring(2);
            str = str2_2 + str2_1 + str1_2 + str1_1;
            return str;
        }

        /// <summary>
        /// ByteToHexStr
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes){
            string returnStr = "";
            if (bytes != null){
                for (int i = 0; i < bytes.Length; i++){
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="st">字符串</param>
        /// <returns>Bool</returns>
        public static bool IsEmpty(this string st)
       {
           return string.IsNullOrWhiteSpace(st);
       }
        /// <summary>
        /// 是否为电话号码
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(this string st)
        {
            if (string.IsNullOrWhiteSpace(st))
            {
                return false;
            }
            Regex reg =  new Regex(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
            return reg.IsMatch(st);
        }
        /// <summary>
        /// 是否为时间格式
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string st)
        {
            if (string.IsNullOrWhiteSpace(st))
            {
                return false;
            }
            DateTime res = DateTime.Now;
            return DateTime.TryParse(st,out res) ;
        }
        /// <summary>
        /// 是否为邮箱地址
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool IsEmail(this string st)
        {
            if (string.IsNullOrWhiteSpace(st))
            {
                return false;
            }
            Regex reg = new Regex(@"^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$");
            return reg.IsMatch(st);
        }
        /// <summary>
        /// URL 参数过滤 把'换成’ 防止SQL 注入
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static string  ParameterChecking(this string st)
       {
           if (st.IsEmpty())
           {
               return string.Empty;
           }
           else
           {
               return st.Replace("'","''");
           }
       }
        public static string CapitalizeFirs(this string st)
        {
            if (st.IsEmpty())
            {
                return string.Empty;
            }
            else
            {
               return st.Substring(0, 1).ToUpper() + st.Substring(1);
            }
        }

    }
}
