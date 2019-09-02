using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// 分页
    /// </summary>
   public class Paging
    {
        public Paging()
        {
            PageIndex = 1;
            PageSize = 20;
            Sort = " order by  ID  asc";
            
        }

        /// <summary>
       /// 当前页
       /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
       /// <summary>
       /// 总页数
       /// </summary>
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalCount / (double)PageSize); } }

       /// <summary>
       /// 总条数
       /// </summary>
        public int TotalCount { get; set; }
       /// <summary>
       /// 排序字段
       /// </summary>
         [JsonIgnore]
        public string Sort { get; set; }
        [JsonIgnore]
        /// <summary>
        /// 开始索引
        /// </summary>
        public int StartItemIndex { get { return (PageIndex - 1) * PageSize + 1; } }
        [JsonIgnore]
      /// <summary>
      /// 结束索引
      /// </summary>
        public int EndItemIndex { get { return TotalCount >PageIndex * PageSize ? PageIndex * PageSize : TotalCount; } }
        /// <summary>
        /// 数量列表
        /// </summary>
        public dynamic List;

    }
}
