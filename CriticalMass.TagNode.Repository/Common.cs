
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using CriticalMass.TagNode.Utility;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace CriticalMass.TagNode.Repository
{
  public static  class Common
    {
        private static IDbConnection GetConnection(){
            return new MySqlConnection(CriticalMass.TagNode.Utility.Config.GetConnectionString());
        }

        public static object MySqlHelloWorld() {
            IDbConnection conn = GetConnection();
            string Sql = "";
            return conn.ExecuteScalar(Sql);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="page">分页</param>
        /// <returns></returns>
        public static Model.Paging GetList(string table,string select,string where, Model.Paging page){
            IDbConnection conn = GetConnection();
            page.TotalCount = conn.Query<int>("select count(0) from  "+ table + " where " + where).First();
            var list = conn.Query(string.Format("select {0} from {1} where {2} {3} limit {4},{5}", select, table, where, page.Sort, page.StartItemIndex - 1, page.PageSize)).ToList();
            page.List = list;
            return page;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="page">分页</param>
        /// <returns></returns>
        public static Model.Paging GetList<T>(string table, string select, string where, Model.Paging page){
            IDbConnection conn = GetConnection();
            page.TotalCount = conn.Query<int>("select count(1) from  " + table + " where " + where).First();
            var list = conn.Query<T>(string.Format("select {0} from {1} where {2} {3} limit {4},{5}", select, table, where, page.Sort, page.StartItemIndex - 1, page.PageSize)).ToList();
            page.List = list;
            return page;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">不带条件</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Model.Paging GetList<T>(string sql,Model.Paging page){
            IDbConnection conn = GetConnection();
            page.TotalCount = conn.Query<int>(string.Format("select count(1) from  ({0}) t",sql)).First();
            var list = conn.Query<T>(string.Format("{0} {1} limit {2},{3}", sql, page.Sort, page.StartItemIndex - 1, page.PageSize)).ToList();
            page.List = list;
            return page;
        }

        public static IEnumerable<T> GetList2<T>(string sql, Model.Paging page) {
            IDbConnection conn = GetConnection();
            return conn.Query<T>(string.Format(sql, page.Sort, page.Sort, page.StartItemIndex, page.PageSize)).ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="table">表名称</param>
        /// <param name="select">查询列</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public static List<T> GetList<T>(string table, string select, string where)
        {
            IDbConnection conn = GetConnection();
            string sql = @"SELECT " + select +" from "+ table + " WHERE "+ where;
            var list = conn.Query<T>(sql).ToList();
            return list;
        }

        /// <summary>
        /// GetList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string sql)
        {
            IDbConnection conn = GetConnection();
            var list = conn.Query<T>(sql).ToList();
            return list;
        }

        /// <summary>
        /// GetObject
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetObject(string sql) {
            IDbConnection conn = GetConnection();
            return conn.ExecuteScalar(sql);
        }

        /// <summary>
        /// ExecSql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecSql(string sql) {
            IDbConnection conn = GetConnection();
            return conn.Execute(sql);
        }
        
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string sql){
            using (IDbConnection connection = GetConnection()){
                DataSet ds = new DataSet();
                try{
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(sql, (MySqlConnection)connection);
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex){
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataTable GetDataTable(string sql){
            using (IDbConnection connection = GetConnection()){
                DataSet ds = new DataSet();
                try{
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(sql, (MySqlConnection)connection);
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex){
                    throw new Exception(ex.Message);
                }
                if (ds == null || ds.Tables.Count == 0) {
                    return null;
                }
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 根据CodeType获取数据列表
        /// </summary>
        /// <param name="codeType"></param>
        /// <returns></returns>
        //public static string GetCodeInfo(string codeType){
        //    List<CriticalMass.TagNode.Model.tCodeInfo> InfoList = GetList<CriticalMass.TagNode.Model.tCodeInfo>(string.Format("SELECT T.CODE,T.CODE_DESC FROM dbo.tCodeInfo T WHERE T.ENABLE_FALG=1 AND T.CODE_TYPE='{0}' ORDER BY T.Sort", codeType));
        //    var PageData = InfoList.Map(a=> {
        //        return new {
        //            id=a.CODE,
        //            text=a.CODE_DESC
        //        };
        //    });
        //    return PageData.ToJson();
        //}

        /// <summary>
        /// 根据codetype和code获取值
        /// </summary>
        /// <param name="codeType"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetCodeDesc(string codeType, string code) {
            string Sql = string.Format("select code_desc from tCodeInfo t where t.code_type='{0}' and t.code='{1}'", codeType,code);
            object o = GetObject(Sql);
            if (o == null) return "";
            return o.ToString();
        }



    }
}
