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
    public class SkuController : BaseController{

        /// <summary>
        /// 单品查询
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string QuerySingleProduct([FromBody] dynamic parameModel) {
            AjaxResult result = new AjaxResult();
            try{
                string Code = parameModel.code;
                //string Code = code;
                var SkuServ = HttpContext.RequestServices.GetService<ItskuRepository>();
                dynamic model=SkuServ.QuerySingleProduct(Code);
                result.Msg = "ok";
                result.Data = model;
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }

        /// <summary>
        /// 添加或修改sku
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddOrModifySku([FromBody] dynamic parameModel) {
            AjaxResult result = new AjaxResult();
            try{
                TransactionOptions options = new TransactionOptions();
                options.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options)) {
                    string product_desc = parameModel.product_desc;
                    int product_id = parameModel.product_id;
                    int createBy = parameModel.createBy;
                    int modifyBy = parameModel.modifyBy;
                    var SkuSrv = HttpContext.RequestServices.GetService<ItskuRepository>();
                    var SkuAttrSrv = HttpContext.RequestServices.GetService<Itsku_attributeRepository>();
                    List<dynamic> lt = ((string)parameModel.product_attributes.ToString()).Str2List<dynamic>();
                    if (Convert.ToInt32(CriticalMass.TagNode.Repository.Common.GetObject(string.Format("select count(1) from tsku t where t.`desc`='{0}'", product_desc))) > 0) {
                        throw new Exception("产品名称已存在!");
                    }
                    //sku
                    CriticalMass.TagNode.Model.tsku s = product_id > 0 ? SkuSrv.GetModel(product_id) : new tsku();
                    s.desc = product_desc;
                    s.status = 1;
                    if (s.id > 0){
                        s.modifyBy = modifyBy;
                        s.modifyTime = DateTime.Now;
                    }
                    else {
                        s.createBy = createBy;
                        s.createTime = DateTime.Now;
                        s.id=SkuSrv.Insert(s);
                        s.code = s.id.IntToHex();
                    }
                    SkuSrv.Update(s);
                    //sku属性
                    CriticalMass.TagNode.Repository.Common.ExecSql(string.Format("update tsku_attribute t set t.status=0 where t.sku_id='{0}'",s.id));
                    lt.Each(a => {
                        int attribute_id = a.attribute_id;
                        List<int> lt_attr_vals = ((string)a.attribute_val_id.ToString()).Str2List<int>();
                        lt_attr_vals.Each(b=> {
                            CriticalMass.TagNode.Model.tsku_attribute SkuAttr = SkuAttrSrv.GetModel(string.Format("sku_id='{0}' and attr_name_id='{1}' and attr_val_id='{2}'", s.id, attribute_id, b));
                            if (SkuAttr == null) {
                                SkuAttr = new tsku_attribute();
                            }
                            SkuAttr.sku_id = s.id;
                            SkuAttr.attr_name_id = attribute_id;
                            SkuAttr.attr_val_id = b;
                            SkuAttr.status = 1;
                            if (SkuAttr.id == 0){
                                SkuAttr.createBy = createBy;
                                SkuAttr.createTime = DateTime.Now;
                                SkuAttrSrv.Insert(SkuAttr);
                            }
                            else {
                                SkuAttrSrv.Update(SkuAttr);
                            }
                        });
                    });
                    CriticalMass.TagNode.Repository.Common.ExecSql(string.Format("delete from tsku_attribute t where t.status=0 and t.sku_id='{0}'",s.id));
                    scope.Complete();
                    result.Data = s.id;
                    result.Msg = "ok";
                }
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
            }
            return result.ToJson();
        }

    }
}