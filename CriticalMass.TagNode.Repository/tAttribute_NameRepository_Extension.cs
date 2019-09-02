using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using CriticalMass.TagNode.IRepository;
using CriticalMass.TagNode.Model;
using CriticalMass.TagNode.Repository;

namespace CriticalMass.TagNode.Repository
{
    public partial class tattribute_nameRepository
    {
        /// <summary>
        /// 根据属性ID获取属性值信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<dynamic> QueryAttributesByAttrId(int id){
            string Sql = string.Format(@"SELECT
                                                an.id  attrId,
                                                an.name,
                                                an.code attrCode,
                                                an.is_custom,
                                                an.canCustom,
                                                an.canMultiSelect,
                                                an.canNull,
                                                av.id  attrValId,
                                                av.val attrVal,
                                                av.code attrValCode,
                                                av.Pid attrValPid
                                            FROM tAttribute_Name an
                                                JOIN tAttribute_Value av ON an.id = av.attrId
                                            WHERE an.status = 1 AND an.is_custom = 0 AND av.is_custom = 0 AND an.id='{0}'", id);
            return Common.GetList<dynamic>(Sql);
        }

        /// <summary>
        /// 根据Pid获取树形数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<dynamic> QueryTreeSubAttributesByPid(int pid){
            string Sql = string.Format("select t.id attrValId,t.val attrVal,t.code attrValCode from tAttribute_Value t where t.pid={0} and t.status=1", pid);
            return Common.GetList<dynamic>(Sql);
        }

        /// <summary>
        /// 查询属性列表
        /// </summary>
        /// <param name="canCustom"></param>
        /// <param name="canMultiSelect"></param>
        /// <param name="canNull"></param>
        /// <param name="ctype"></param>
        /// <param name="name"></param>
        /// <param name="attrCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Paging QueryAttributeList(int? canCustom, int? canMultiSelect, int? canNull, string ctype = "", string name = "", string attrCode = "", int pageIndex = 1, int pageSize = 10){
            string Where = " and 1=1 ";
            if (canCustom != null){
                Where += string.Format(" and t.canCustom='{0}'", canCustom);
            }
            if (canMultiSelect != null){
                Where += string.Format(" and t.canMultiSelect='{0}'", canMultiSelect);
            }
            if (canNull != null){
                Where += string.Format(" and t.canNull='{0}'", canNull);
            }
            if (!string.IsNullOrEmpty(ctype)){
                Where += string.Format(" and t.ctype='{0}'", ctype);
            }
            if (!string.IsNullOrEmpty(name)){
                Where += string.Format(" and t.name like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(attrCode)){
                Where += string.Format(" and t.code='{0}'", attrCode);
            }
            string Sql = string.Format("select t.id attrId,t.name,t.code attrCode,t.canCustom,t.canMultiSelect,t.canNull,t.ctype from tAttribute_Name t where t.status=1 and t.is_custom=0 {0}", Where);
            Paging pag = new Paging();
            pag.PageIndex = pageIndex;
            pag.PageSize = pageSize;
            pag.Sort = "order by attrId desc";
            Common.GetList<dynamic>(Sql, pag);
            return pag;
        }
    }
}
