using System;
using System.ComponentModel;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// 开发者APP表
    /// </summary>
    public partial class tapi_tagnode_app
    {
        /// <summary>
        /// id
        /// </summary>	
        [Description("id")]
        [DisplayName("id")]
        public Int32 id { get; set; }

        /// <summary>
        /// 开发者ID
        /// </summary>	
        [Description("did")]
        [DisplayName("did")]
        public Int32 did { get; set; }

        /// <summary>
        /// app名称
        /// </summary>	
        [Description("app_name")]
        [DisplayName("app_name")]
        public String app_name { get; set; }

        /// <summary>
        /// app描述
        /// </summary>	
        [Description("app_desc")]
        [DisplayName("app_desc")]
        public String app_desc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>	
        [Description("createTime")]
        [DisplayName("createTime")]
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>	
        [Description("createBy")]
        [DisplayName("createBy")]
        public Int32 createBy { get; set; }

        /// <summary>
        /// key
        /// </summary>	
        [Description("appkey")]
        [DisplayName("appkey")]
        public String appkey { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>	
        [Description("appsecret")]
        [DisplayName("appsecret")]
        public String appsecret { get; set; }

        /// <summary>
        /// 状态
        /// </summary>	
        [Description("status")]
        [DisplayName("status")]
        public Int32 status { get; set; }

        /// <summary>
        /// 审核
        /// </summary>	
        [Description("audit")]
        [DisplayName("audit")]
        public Int32 audit { get; set; }

    }
}
