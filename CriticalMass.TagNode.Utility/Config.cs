using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace CriticalMass.TagNode.Utility
{
    public static class Config
    {
        public static IConfiguration Configuration { get; set; }

        static Config() {
            Configuration = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();
        }

        public static string GetConnectionString()
        {
            return Configuration.GetConnectionString("DefaultConnectionString");
        }
        /// <summary>
        /// 默认时间
        /// </summary>
        /// <returns></returns>
        public static DateTime DefautlDateTime()
        {
            return DateTime.Parse("1970-01-01 00:00:00");
        }
    }
}
