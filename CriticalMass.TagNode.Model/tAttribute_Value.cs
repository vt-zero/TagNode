using System;
using System.ComponentModel;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// 属性值表
    /// </summary>
    public partial class tattribute_value
    {
        /// <summary>
        /// id
        /// </summary>	
        [Description("id")]
        [DisplayName("id")]
        public Int32 id { get; set; }

        /// <summary>
        /// 值
        /// </summary>	
        [Description("val")]
        [DisplayName("val")]
        public String val { get; set; }

        /// <summary>
        /// 值编码
        /// </summary>	
        [Description("code")]
        [DisplayName("code")]
        public String code { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>	
        [Description("Pid")]
        [DisplayName("Pid")]
        public Int32 Pid { get; set; }

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
        /// 状态
        /// </summary>	
        [Description("status")]
        [DisplayName("status")]
        public Int32 status { get; set; }

        /// <summary>
        /// 是否自定义
        /// </summary>	
        [Description("is_custom")]
        [DisplayName("is_custom")]
        public Int32 is_custom { get; set; }

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
        /// 属性名ID
        /// </summary>	
        [Description("attrId")]
        [DisplayName("attrId")]
        public Int32 attrId { get; set; }

    }
}
