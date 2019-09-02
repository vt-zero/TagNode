using System;
using System.ComponentModel;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// sku属性关联表
    /// </summary>
    public partial class tsku_attribute
    {
        /// <summary>
        /// id
        /// </summary>	
        [Description("id")]
        [DisplayName("id")]
        public Int32 id { get; set; }

        /// <summary>
        /// skuID
        /// </summary>	
        [Description("sku_id")]
        [DisplayName("sku_id")]
        public Int32 sku_id { get; set; }

        /// <summary>
        /// 属性名ID
        /// </summary>	
        [Description("attr_name_id")]
        [DisplayName("attr_name_id")]
        public Int32 attr_name_id { get; set; }

        /// <summary>
        /// 属性值ID
        /// </summary>	
        [Description("attr_val_id")]
        [DisplayName("attr_val_id")]
        public Int32 attr_val_id { get; set; }

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
        /// status
        /// </summary>	
        [Description("status")]
        [DisplayName("status")]
        public Int32 status { get; set; }

    }
}
