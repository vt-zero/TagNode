using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CriticalMass.TagNode.Model;

namespace CriticalMass.TagNode.IRepository
{
    public partial interface Itapi_tagnode_appRepository : IRepository
    {

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CriticalMass.TagNode.Model.tapi_tagnode_app GetModel(long id);

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CriticalMass.TagNode.Model.tapi_tagnode_app GetModel(string where);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="page">分页</param>
        /// <returns></returns>
        CriticalMass.TagNode.Model.Paging GetList(string where, CriticalMass.TagNode.Model.Paging page);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        List<CriticalMass.TagNode.Model.tapi_tagnode_app> GetList(string where);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        bool Exists(string where);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where">条件</param>
        ///<param name="parameter">参数</param>
        /// <returns></returns>
        bool Exists(string where, object parameter);

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="where">条件</param>
        ///<param name="parameter">参数</param>
        /// <returns></returns>
        int Count(string where, object parameter);

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        long GetId(string where);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="where">条件</param>
        ///<param name="parameter">参数</param>
        /// <returns></returns>
        bool Exists(string where, CriticalMass.TagNode.Model.tapi_tagnode_app parameter);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool Del(long id);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool Del(long id, IDbTransaction trn);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool Del(string where, CriticalMass.TagNode.Model.tapi_tagnode_app parameter);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool Del(string where, CriticalMass.TagNode.Model.tapi_tagnode_app parameter, IDbTransaction trn);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool DelByNoParameter(string where);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool DelByNoParameter(string where, IDbTransaction trn);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Del(string ids);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Del(string ids, IDbTransaction trn);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Update(CriticalMass.TagNode.Model.tapi_tagnode_app model, IDbTransaction trn);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Update(CriticalMass.TagNode.Model.tapi_tagnode_app model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Update(string field, CriticalMass.TagNode.Model.tapi_tagnode_app model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        int Update(string field, string where);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        int Update(string field, string where, IDbTransaction trn);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Update(string field, CriticalMass.TagNode.Model.tapi_tagnode_app model, IDbTransaction trn);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Insert(CriticalMass.TagNode.Model.tapi_tagnode_app model);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Insert(CriticalMass.TagNode.Model.tapi_tagnode_app model, IDbTransaction trn);
    }
}
