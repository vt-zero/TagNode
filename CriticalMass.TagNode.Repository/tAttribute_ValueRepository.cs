
using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CriticalMass.TagNode.IRepository;
using CriticalMass.TagNode.Model;
using MySql.Data.MySqlClient;

namespace CriticalMass.TagNode.Repository
{
    public partial class tattribute_valueRepository : BaseRepository, Itattribute_valueRepository
    {
        #region BasicMethod
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CriticalMass.TagNode.Model.tattribute_value GetModel(long id)
        {
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"SELECT `id`,`val`,`code`,`Pid`,`createBy`,`createTime`,`status`,`is_custom`,`modifyBy`,`modifyTime`,`attrId` from tattribute_value where ID=" + id + " limit 1";
            return conn.Query<CriticalMass.TagNode.Model.tattribute_value>(sqlCommandText).SingleOrDefault();
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CriticalMass.TagNode.Model.tattribute_value GetModel(string where)
        {
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"select `id`,`val`,`code`,`Pid`,`createBy`,`createTime`,`status`,`is_custom`,`modifyBy`,`modifyTime`,`attrId` from  tattribute_value where " + where + " limit 1";
            return conn.Query<CriticalMass.TagNode.Model.tattribute_value>(sqlCommandText).SingleOrDefault();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="page">分页</param>
        /// <returns></returns>
        public CriticalMass.TagNode.Model.Paging GetList(string where, CriticalMass.TagNode.Model.Paging page)
        {
            IDbConnection conn = base.GetConnection();
            page.TotalCount = conn.Query<int>("select count(0) from tattribute_value where " + where).First();
            string sql = @"SELECT `id`,`val`,`code`,`Pid`,`createBy`,`createTime`,`status`,`is_custom`,`modifyBy`,`modifyTime`,`attrId` FROM tattribute_value WHERE {0} {1} limit {2},{3}";
            var list = conn.Query<CriticalMass.TagNode.Model.tattribute_value>(string.Format(sql, where, page.Sort, page.StartItemIndex, page.PageSize)).ToList();
            page.List = list;
            return page;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public List<CriticalMass.TagNode.Model.tattribute_value> GetList(string where)
        {
            IDbConnection conn = base.GetConnection();
            string sql = @"SELECT `id`,`val`,`code`,`Pid`,`createBy`,`createTime`,`status`,`is_custom`,`modifyBy`,`modifyTime`,`attrId` FROM tattribute_value WHERE {0} ";
            var list = conn.Query<CriticalMass.TagNode.Model.tattribute_value>(string.Format(sql, where)).ToList();
            return list;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public bool Exists(string where)
        {
            IDbConnection conn = base.GetConnection();
            string sql = @"SELECT count(0) FROM tattribute_value WHERE {0} ";
            int res = conn.Query<int>(string.Format(sql, where)).First();
            return res > 0;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where">条件</param>
        ///<param name="parameter">参数</param>
        /// <returns></returns>
        public bool Exists(string where, object parameter)
        {
            IDbConnection conn = base.GetConnection();
            string sql = @"SELECT count(0) FROM tattribute_value WHERE {0} ";
            int res = conn.Query<int>(string.Format(sql, where), parameter).First();
            return res > 0;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="where">条件</param>
        ///<param name="parameter">参数</param>
        /// <returns></returns>
        public int Count(string where, object parameter)
        {
            IDbConnection conn = base.GetConnection();
            string sql = @"SELECT count(0) FROM tattribute_value WHERE {0} ";
            int res = conn.Query<int>(string.Format(sql, where), parameter).First();
            return res;
        }

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public long GetId(string where)
        {
            IDbConnection conn = base.GetConnection();
            string sql = @"SELECT ID FROM tattribute_value WHERE {0} limit 1";
            long res = conn.Query<long>(string.Format(sql, where)).FirstOrDefault();
            return res;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where">条件</param>
        ///<param name="parameter">参数</param>
        /// <returns></returns>
        public bool Exists(string where, CriticalMass.TagNode.Model.tattribute_value parameter)
        {
            IDbConnection conn = base.GetConnection();
            string sql = @"SELECT count(0) FROM tattribute_value WHERE {0} ";
            int res = conn.Query<int>(string.Format(sql, where), parameter).First();
            return res > 0;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool Del(long id)
        {
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"delete from tattribute_value where id=@id";
            return conn.Execute(sqlCommandText, new { id = id }) > 0 ? true : false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool Del(long id, IDbTransaction trn)
        {
            IDbConnection conn = trn.Connection;
            string sqlCommandText = @"delete from tattribute_value where id=@id";
            return conn.Execute(sqlCommandText, new { id = id }, trn) > 0 ? true : false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool Del(string where, CriticalMass.TagNode.Model.tattribute_value parameter)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                return false;
            }
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"delete from tattribute_value where " + where;
            return conn.Execute(sqlCommandText, parameter) > 0 ? true : false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool Del(string where, CriticalMass.TagNode.Model.tattribute_value parameter, IDbTransaction trn)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                return false;
            }
            IDbConnection conn = trn.Connection;
            string sqlCommandText = @"delete from tattribute_value where " + where;
            return conn.Execute(sqlCommandText, parameter, trn) > 0 ? true : false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool DelByNoParameter(string where)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                return false;
            }
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"delete from tattribute_value where " + where;
            return conn.Execute(sqlCommandText) > 0 ? true : false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public bool DelByNoParameter(string where, IDbTransaction trn)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                return false;
            }
            IDbConnection conn = trn.Connection;
            string sqlCommandText = @"delete from tattribute_value where " + where;
            return conn.Execute(sqlCommandText, trn) > 0 ? true : false;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Del(string ids)
        {
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"delete from tattribute_value where id in (" + ids + ")";
            int res = conn.Execute(sqlCommandText);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Del(string ids, IDbTransaction trn)
        {
            IDbConnection conn = trn.Connection;
            string sqlCommandText = @"delete from tattribute_value where id in (" + ids + ")";
            int res = conn.Execute(sqlCommandText, trn);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Update(CriticalMass.TagNode.Model.tattribute_value model, IDbTransaction trn)
        {
            IDbConnection conn = trn.Connection;
            string sqlCommandText = @"update tattribute_value set `val`=@val,`code`=@code,`Pid`=@Pid,`createBy`=@createBy,`createTime`=@createTime,`status`=@status,`is_custom`=@is_custom,`modifyBy`=@modifyBy,`modifyTime`=@modifyTime,`attrId`=@attrId where id=@id";
            return conn.Execute(sqlCommandText, model, trn) > 0 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Update(CriticalMass.TagNode.Model.tattribute_value model)
        {
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"update tattribute_value set `val`=@val,`code`=@code,`Pid`=@Pid,`createBy`=@createBy,`createTime`=@createTime,`status`=@status,`is_custom`=@is_custom,`modifyBy`=@modifyBy,`modifyTime`=@modifyTime,`attrId`=@attrId where id=@id";
            return conn.Execute(sqlCommandText, model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Update(string field, CriticalMass.TagNode.Model.tattribute_value model)
        {
            IDbConnection conn = base.GetConnection();
            if (model.id <= 0)
            {
                return false;
            }
            string sqlCommandText = @"update tattribute_value set " + field + " where id=@id";
            return conn.Execute(sqlCommandText, model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public int Update(string field, string where)
        {
            IDbConnection conn = base.GetConnection();
            if (string.IsNullOrWhiteSpace(where))
            {
                return 0;
            }
            string sqlCommandText = @"update tattribute_value set " + field + " where " + where;
            return conn.Execute(sqlCommandText);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public int Update(string field, string where, IDbTransaction trn)
        {
            IDbConnection conn = trn.Connection;
            if (string.IsNullOrWhiteSpace(where))
            {
                return 0;
            }
            string sqlCommandText = @"update tattribute_value set " + field + " where " + where;
            return conn.Execute(sqlCommandText);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Update(string field, CriticalMass.TagNode.Model.tattribute_value model, IDbTransaction trn)
        {
            IDbConnection conn = trn.Connection;
            if (model.id <= 0)
            {
                return false;
            }
            string sqlCommandText = @"update tattribute_value set " + field + " where id=@id";
            return conn.Execute(sqlCommandText, model, trn) > 0 ? true : false;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(CriticalMass.TagNode.Model.tattribute_value model)
        {
            IDbConnection conn = base.GetConnection();
            string sqlCommandText = @"insert into tattribute_value(`val`,`code`,`Pid`,`createBy`,`createTime`,`status`,`is_custom`,`modifyBy`,`modifyTime`,`attrId`)values(@val,@code,@Pid,@createBy,@createTime,@status,@is_custom,@modifyBy,@modifyTime,@attrId);SELECT ifnull(@@IDENTITY,0)";
            return conn.Query<int>(sqlCommandText, model).First();
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(CriticalMass.TagNode.Model.tattribute_value model, IDbTransaction trn)
        {
            IDbConnection conn = trn.Connection;
            string sqlCommandText = @"insert into tattribute_value(`val`,`code`,`Pid`,`createBy`,`createTime`,`status`,`is_custom`,`modifyBy`,`modifyTime`,`attrId`)values(@val,@code,@Pid,@createBy,@createTime,@status,@is_custom,@modifyBy,@modifyTime,@attrId);SELECT ifnull(@@IDENTITY,0)";
            return conn.Query<int>(sqlCommandText, model, trn).First();
        }
        #endregion
    }
}

