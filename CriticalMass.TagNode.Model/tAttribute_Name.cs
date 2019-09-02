using System;
using System.ComponentModel;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// 属性名称表
    /// </summary>
    public partial class tattribute_name
    {
        /// <summary>
        /// id
        /// </summary>	
        [Description("id")]
        [DisplayName("id")]
        public Int32 id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>	
        [Description("name")]
        [DisplayName("name")]
        public String name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>	
        [Description("code")]
        [DisplayName("code")]
        public String code { get; set; }

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
        /// 是否可多选
        /// </summary>	
        [Description("canMultiSelect")]
        [DisplayName("canMultiSelect")]
        public Int32 canMultiSelect { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>	
        [Description("canNull")]
        [DisplayName("canNull")]
        public Int32 canNull { get; set; }

        /// <summary>
        /// 是否可自定义
        /// </summary>	
        [Description("canCustom")]
        [DisplayName("canCustom")]
        public Int32 canCustom { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>	
        [Description("ctype")]
        [DisplayName("ctype")]
        public String ctype { get; set; }

    }
}
