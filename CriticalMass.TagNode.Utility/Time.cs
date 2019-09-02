using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMass.TagNode.Utility
{
   public static class Time
    {
        /// <summary>
        /// 默认时间显示
        /// </summary>
        /// <param name="defalut">默认显示</param>
        /// <returns></returns>
        public static string CheckDefaultDateTime(this DateTime time,string defalut="-")
        {
            if (time == null)
            {
                return defalut;
            }
            if (time== Config.DefautlDateTime())
            {
                return defalut;
            }
            else
            {
                return time.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
