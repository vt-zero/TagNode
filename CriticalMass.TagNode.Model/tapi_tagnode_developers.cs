using System;
using System.ComponentModel;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// 开发者表
    /// </summary>
    public partial class tapi_tagnode_developers
    {
        /// <summary>
        /// id
        /// </summary>	
        [Description("id")]
        [DisplayName("id")]
        public Int32 id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>	
        [Description("username")]
        [DisplayName("username")]
        public String username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>	
        [Description("password")]
        [DisplayName("password")]
        public String password { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>	
        [Description("createBy")]
        [DisplayName("createBy")]
        public Int32 createBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>	
        [Description("createTime")]
        [DisplayName("createTime")]
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>	
        [Description("modifyBy")]
        [DisplayName("modifyBy")]
        public Int32 modifyBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>	
        [Description("modifyTime")]
        [DisplayName("modifyTime")]
        public DateTime? modifyTime { get; set; }

    }
}
