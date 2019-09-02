using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMass.TagNode.Repository
{
    public partial class tskuRepository
    {
        /// <summary>
        /// 单品查询
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public dynamic QuerySingleProduct(string code) {
            string Sql = string.Format(@"SELECT s.id,s.code,s.`desc` remark,s.createtime FROM tSku S where s.code='{0}'", code);
            return Common.GetList<dynamic>(Sql)[0];
        }
    }
}
