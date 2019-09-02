using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CriticalMass.TagNode.Model;

namespace CriticalMass.TagNode.IRepository
{
    public partial interface ItAttribute_NameRepository : IRepository
    {

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CriticalMass.TagNode.Model.tattribute_name GetModel(long id);

        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CriticalMass.TagNode.Model.tattribute_name GetModel(string where);

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
        List<CriticalMass.TagNode.Model.tattribute_name> GetList(string where);

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
        bool Exists(string where, CriticalMass.TagNode.Model.tattribute_name parameter);

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
        bool Del(string where, CriticalMass.TagNode.Model.tattribute_name parameter);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        bool Del(string where, CriticalMass.TagNode.Model.tattribute_name parameter, IDbTransaction trn);

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
        bool Update(CriticalMass.TagNode.Model.tattribute_name model, IDbTransaction trn);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Update(CriticalMass.TagNode.Model.tattribute_name model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Update(string field, CriticalMass.TagNode.Model.tattribute_name model);

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
        bool Update(string field, CriticalMass.TagNode.Model.tattribute_name model, IDbTransaction trn);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Insert(CriticalMass.TagNode.Model.tattribute_name model);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Insert(CriticalMass.TagNode.Model.tattribute_name model, IDbTransaction trn);

        /// <summary>
        /// 根据属性id查询属性值信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<dynamic> QueryAttributesByAttrId(int id);

        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<dynamic> QueryTreeSubAttributesByPid(int pid);

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
        Paging QueryAttributeList(int? canCustom, int? canMultiSelect, int? canNull, string ctype = "", string name = "", string attrCode = "", int pageIndex = 1, int pageSize = 10);

    }
}