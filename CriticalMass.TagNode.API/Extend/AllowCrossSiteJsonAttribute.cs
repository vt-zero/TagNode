using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CriticalMass.TagNode.API.Extend
{
    /// <summary>
    /// 跨域
    /// </summary>
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext){
            base.OnActionExecuted(actionExecutedContext);
            //该种跨域方式form传参有用  raw传参无用
            //if (actionExecutedContext.HttpContext.Response != null){
            //    actionExecutedContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //    actionExecutedContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //    actionExecutedContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            //    actionExecutedContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            //}
        }
    }
}
