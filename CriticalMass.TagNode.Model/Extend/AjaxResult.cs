using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CriticalMass.TagNode.Model;

namespace CriticalMass.TagNode.Model
{
    /// <summary>
    /// Ajax
    /// </summary>
    public class AjaxResult
    {
        public AjaxResult()
        {
            State = 1;
            DataType = 1;
            Msg = "undefined";
            ErrorField = "undefined";
            Url = "undefined";
        }

        /// <summary>
        /// 状态 1.成功 2.失败 3.错误 4.未登录 5.无权限
        /// </summary>
        public int State;
       
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg;
        /// <summary>
        /// 分页
        /// </summary>
        public Paging Page;
        /// <summary>
        /// 1.数据在Data中 2.在Page中
        /// </summary>
        public int DataType;
        /// <summary>
        /// 数据
        /// </summary>
        public object Data;
        /// <summary>
        /// 地址
        /// </summary>
        public string Url;
        /// <summary>
        /// 错误字段
        /// </summary>
        public string ErrorField;

    }
}
