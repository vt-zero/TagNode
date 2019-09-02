/*
 【API签名】
签名需要参数：app_key+调用方法名称+json字符串+app_secret 
参数处理：
1、json字符串内的key按照从小到大的顺序排列
2、app_key+调用方法名称+json字符串+app_secret 拼接起来，转小写
3、去掉所有=、&、空格、单引号、双引号、及换行等空白字符
4、拼接的字符串md5加密得到sign
方法名称:api_controller_action
调用：
在请求头（header）里加入app_key和sign两个参数
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using CriticalMass.TagNode.Utility;
using System.Data;
using CriticalMass.TagNode.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace CriticalMass.TagNode.API.Extend
{
    /// <summary>
    /// 签名验证
    /// </summary>
    public class TokenCheckAttribute: ActionFilterAttribute{

        public void WriteLog(string info) {
            try
            {
                StreamWriter sw = new StreamWriter(string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")), true, System.Text.Encoding.Default);
                sw.Write(string.Format("{0}:{1}\r\n", DateTime.Now, info+"\r\n\r\n"));
                sw.Flush();
                sw.Close();
            }
            catch { }
        }

        public override void OnActionExecuting(ActionExecutingContext context){
            base.OnActionExecuting(context);
            AjaxResult result = new AjaxResult();
            result.Msg = "ok";
            try{
                string Controller = context.RouteData.Values["controller"].ToString();
                string ActionName = context.RouteData.Values["action"].ToString();
                string AppKey = context.HttpContext.Request.Headers["app_key"].ToString();
                string Sign = context.HttpContext.Request.Headers["sign"].ToString();
                string Func = "api_" + Controller + "_" + ActionName;
                if (string.IsNullOrEmpty(Controller) || string.IsNullOrEmpty(ActionName) || string.IsNullOrEmpty(AppKey) || string.IsNullOrEmpty(Sign)) {
                    result.Msg = "Unauthorized access.";
                    context.Result = new ContentResult() { Content = result.ToJson() };
                    return;
                }
                string AppSecret = "";
                DataTable dt = CriticalMass.TagNode.Repository.Common.GetDataTable(string.Format("select ifnull(t.status,0) status,ifnull(t.audit,0) audit,t.appsecret from tapi_tagnode_app t where t.appkey='{0}'", AppKey));
                if (dt == null || dt.Rows.Count == 0){
                    result.Msg = "AppKey错误.";
                    context.Result = new ContentResult() { Content = result.ToJson() };
                    return;
                }
                DataRow dr = dt.Rows[0];
                if (dr["status"].ToString() == "0" || dr["audit"].ToString() == "0"){
                    result.Msg = "Token未生效.";
                    context.Result = new ContentResult() { Content = result.ToJson() };
                    return;
                }
                AppSecret = dr["appsecret"].ToString();
                //获取参数集合
                Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
                if (context.HttpContext.Request.ContentLength > 0 && context.HttpContext.Request.ContentType != null) {
                    if (context.HttpContext.Request.ContentType.ToLower() == "application/json" && context.HttpContext.Request.Body != null && context.HttpContext.Request.Body.Length > 0){
                        using (var ms = new MemoryStream())
                        {
                            context.HttpContext.Request.Body.Seek(0,0);
                            context.HttpContext.Request.Body.CopyTo(ms);
                            ms.Position = 0;
                            StreamReader sr = new StreamReader(ms,System.Text.Encoding.UTF8);
                            string str = sr.ReadToEnd();
                            if (!string.IsNullOrEmpty(str)){
                                dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(str);
                            }
                        }
                    }
                    else if (context.HttpContext.Request.Form.Count > 0){
                        for (int i = 0; i < context.HttpContext.Request.Form.Count; i++){
                            string Key = context.HttpContext.Request.Form.Keys.ToList()[i];
                            dic[Key] = context.HttpContext.Request.Form[Key].ToString();
                        }
                    }
                }
                
                dic = dic.OrderBy(a => a.Key).ToDictionary(p=>p.Key,o=>o.Value);
                string ParamesJsonStr = dic.ToJson().Replace("=", "").Replace("&", "").Replace(" ", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("'","").Replace("\\\"","").Replace("\t","").Replace("\\n", "").Replace("\\t", "").Replace("\"","").ToLower();
                string Sign_G = (AppKey + Func + ParamesJsonStr + AppSecret).ToLower().ToMd5();
                WriteLog(AppKey + Func + ParamesJsonStr + AppSecret);
                if (Sign_G != Sign.ToLower()) {
                    result.Msg = "签名错误.";
                    context.Result = new ContentResult() { Content = result.ToJson() };
                    return;
                }
            }
            catch (Exception ex) {
                result.Msg = ex.Message;
                context.Result = new ContentResult() { Content = result.ToJson() };
                return;
            }
        }
    }
}
