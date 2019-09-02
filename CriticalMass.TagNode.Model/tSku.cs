using System;
using System.ComponentModel;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// sku表
    /// </summary>
    public partial class tsku
    {
        /// <summary>
        /// id
        /// </summary>	
        [Description("id")]
        [DisplayName("id")]
        public Int32 id { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>	
        [Description("code")]
        [DisplayName("code")]
        public String code { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>	
        [Description("desc")]
        [DisplayName("desc")]
        public String desc { get; set; }

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

        /// <summary>
        /// 状态
        /// </summary>	
        [Description("status")]
        [DisplayName("status")]
        public Int32 status { get; set; }

    }
}
