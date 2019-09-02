using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CriticalMass.TagNode.Model;
using CriticalMass.TagNode.Repository;
using CriticalMass.TagNode.IRepository;
using CriticalMass.TagNode.Utility;
using System.Transactions;
using Microsoft.Extensions.DependencyInjection;
using CriticalMass.TagNode.API.Extend;

namespace TagNode.Controllers
{
    public class AttributeController : BaseController{

        #region 属性查询接口
        /// <summary>
        /// 获取属性列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string QueryAttributeList([FromBody] dynamic parameModel) {
            int? canCustom = parameModel.canCustom;
            int? canMultiSelect = parameModel.canMultiSelect;
            int? canNull = parameModel.canNull;
            string ctype = parameModel.ctype;
            string name = parameModel.name;
            string attrCode = parameModel.attrCode;
            int pageIndex = parameModel.pageIndex==null ? 1 : parameModel.pageIndex;
            int pageSize = parameModel.pageSize==null ? 10 : parameModel.pageSize;
            var AttrSrv = HttpContext.RequestServices.GetService<ItAttribute_NameRepository>();
            Paging pag =AttrSrv.QueryAttributeList(canCustom, canMultiSelect, canNull, ctype, name, attrCode, pageIndex, pageSize);
            var PageData = new{
                total = pag.TotalCount,
                rows = pag.List
            };
            return PageData.ToJson();
        }

        private List<dynamic> GetSubValus(int pid,List<dynamic> lt) {
            return lt.FindAll(a => a.attrValPid == pid).Map<dynamic, dynamic>(a=> {
                return new {
                    attrValId = a.attrValId,
                    attrVal = a.attrVal,
                    attrValCode = a.attrValCode,
                    attrValPid = a.attrValPid,
                    subvals = GetSubValus(a.attrValId, lt)
                };
            }).ToList();
        }

        /// <summary>
        /// 根据属性名ID获取属性值
        /// </summary>
        /// <returns></returns>
        public string QueryAttributesByAttrId([FromBody] dynamic parameModel) {
            AjaxResult result = new AjaxResult();
            try{
                int attrId = parameModel.attrId;
                var AttrNameSrv = HttpContext.RequestServices.GetService<ItAttribute_NameRepository>();
                List<dynamic> lt =AttrNameSrv.QueryAttributesByAttrId(attrId);
                List<dynamic> ltVals = lt.FindAll(a=>a.attrValPid == 0).Map<dynamic, dynamic>(a =>{
                    return new{
                        attrValId = a.attrValId,
                        attrVal = a.attrVal,
                        attrValCode = a.attrValCode,
                        attrValPid=a.attrValPid,
                        subvals= GetSubValus(a.attrValId, lt)
                    };
                }).ToList();
                var Attr = new {
                    attrId=lt[0].attrId,
                    name=lt[0].name,
                    attrCode=lt[0].attrCode,
                    canCustom=lt[0].canCustom,
                    canMultiSelect=lt[0].canMultiSelect,
                    canNull=lt[0].canNull,
                    attrs = ltVals
                };
                result.Msg = "ok";
                result.Data = Attr;
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }

        /// <summary>
        /// 查询树形接口属性
        /// </summary>
        /// <returns></returns>
        public string QueryTreeSubAttributesByPid(int pid) {
            AjaxResult result = new AjaxResult();
            try{
                var AttrNameSrv = HttpContext.RequestServices.GetService<ItAttribute_NameRepository>();
                List<dynamic> lt = AttrNameSrv.QueryTreeSubAttributesByPid(pid);
                result.Data = lt;
                result.Msg = "ok";
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }
        #endregion

        #region 属性添加和修改接口
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public string AddOrModifyAttribute([FromBody] dynamic parameModel) {
            AjaxResult result = new AjaxResult();
            try{
                TransactionOptions options = new TransactionOptions();
                options.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options)) {
                    dynamic model = parameModel;
                    var AttrNameService = HttpContext.RequestServices.GetService<ItAttribute_NameRepository>();
                    int AttrId = model.attrId;
                    CriticalMass.TagNode.Model.tattribute_name AttrName = AttrId==0 ? new CriticalMass.TagNode.Model.tattribute_name() : AttrNameService.GetModel(AttrId);
                    if (AttrName.id > 0 && AttrNameService.Exists(string.Format("name='{0}' and id<>'{1}'", model.attrName.ToString(), AttrName.id))){
                        throw new Exception("属性名已存在,请使用其他名称!");
                    }
                    else if(AttrName.id==0 && AttrNameService.Exists(string.Format("name='{0}'", model.attrName.ToString()))) {
                        throw new Exception("属性名已存在,请使用其他名称!");
                    }
                    AttrName.canMultiSelect = model.canMultiSelect;
                    AttrName.canNull = model.canNull;
                    AttrName.canCustom = model.canCustom;
                    AttrName.name = model.attrName;
                    AttrName.ctype = model.ctype;
                    if (AttrId == 0){
                        AttrName.createBy = model.createBy;
                        AttrName.createTime = DateTime.Now;
                        AttrName.status = 1;
                        AttrName.id = AttrNameService.Insert(AttrName);
                        AttrName.code = AttrName.id.IntToHex();
                    }
                    else {
                        AttrName.modifyBy = model.modifyBy;
                        AttrName.modifyTime = DateTime.Now;
                    }
                    AttrNameService.Update(AttrName);
                    if (model.subValues == null || model.subValues.ToString() == "[]"){
                        throw new Exception("值不能为空.");
                    }
                    CriticalMass.TagNode.Repository.Common.ExecSql(string.Format("update tattribute_value t set t.status=0 where t.attrId='{0}'", AttrName.id));
                    string subValues = model.subValues.ToString();
                    AddSubValues(AttrName.id, 0, AttrName.createBy, AttrName.modifyBy, subValues);
                    CriticalMass.TagNode.Repository.Common.ExecSql(string.Format("delete from tattribute_value t where t.status=0 and t.attrId='{0}'",AttrName.id));
                    result.Msg = "ok";
                    scope.Complete();
                }
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }

        /// <summary>
        /// 递归添加子项
        /// </summary>
        /// <param name="attrId"></param>
        /// <param name="pid"></param>
        private void AddSubValues(int attrId, int pid,int createBy,int modifyBy, string subValues) {
            List<dynamic> lt=((string)subValues).ToString().Str2List<dynamic>();
            var ValueService = HttpContext.RequestServices.GetService<Itattribute_valueRepository>();
            if (lt != null && lt.Count != 0) {
                lt.Each(a =>{
                    int attrValId = a.attrValId;
                    string val = a.val;
                    CriticalMass.TagNode.Model.tattribute_value model = attrValId==0 ? new CriticalMass.TagNode.Model.tattribute_value() : ValueService.GetModel(attrValId);
                    if (model.id > 0 && ValueService.Exists(string.Format("val='{0}' and id<>'{1}' and attrid='{2}'", val, model.id, attrId))){
                        throw new Exception("属性值重复.");
                    }
                    else if (model.id == 0 && ValueService.Exists(string.Format("val='{0}' and attrid='{1}'", val, attrId))) {
                        throw new Exception("属性值重复.");
                    }
                    model.val = val;
                    model.attrId = attrId;
                    model.Pid = pid;
                    model.status = 1;
                    if (attrValId == 0){
                        model.createBy = createBy;
                        model.createTime = DateTime.Now;
                        int ValId = ValueService.Insert(model);
                        model.id = ValId;
                        model.code = model.id.IntToHex();//生成值Code
                    }
                    else {
                        model.modifyBy = modifyBy;
                        model.modifyTime = DateTime.Now;
                    }
                    ValueService.Update(model);
                    subValues = a.subValues.ToString();
                    AddSubValues(attrId, model.id, createBy, modifyBy, subValues);
                });
            }
        }
        #endregion

        #region 属性删除接口
        /// <summary>
        /// 删除属性值
        /// </summary>
        /// <param name="attrValueId"></param>
        /// <returns></returns>
        public string RemoveAttrbuteValue([FromBody] dynamic parameModel) {
            AjaxResult result = new AjaxResult();
            try{
                int attrValueId = parameModel.attrValueId;
                var ValueServ = HttpContext.RequestServices.GetService<Itattribute_valueRepository>();
                ValueServ.Del(attrValueId);
                result.Msg = "ok";
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="attrId"></param>
        /// <returns></returns>
        public string RemoveAttribute([FromBody] dynamic parameModel) {
            AjaxResult result = new AjaxResult();
            try{
                int attrId = parameModel.attrId;
                var AttrServ = HttpContext.RequestServices.GetService<ItAttribute_NameRepository>();
                var ValueServ = HttpContext.RequestServices.GetService<Itattribute_valueRepository>();
                ValueServ.DelByNoParameter(string.Format("attrId='{0}'", attrId));
                AttrServ.Del(attrId);
                result.Msg = "ok";
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }
        #endregion

    }
}