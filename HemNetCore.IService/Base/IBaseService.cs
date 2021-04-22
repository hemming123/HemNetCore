using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HemNetCore.Model;
using SqlSugar;

namespace HemNetCore.IService.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> Add(TEntity model);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        Task<int> Add(List<TEntity> listEntity);


        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="insertColumns">指定只插入列</param>
        /// <returns>返回自增量列</returns>
        Task<int> Add(TEntity entity, Expression<Func<TEntity, object>> insertColumns = null);

        #endregion


        #region 修改


        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity);

        /// <summary>
        /// 根据model，更新，带where条件
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity, string strWhere);

        /// <summary>
        /// 根据Model，更新，不带where条件
        /// </summary>
        /// <param name="operateAnonymousObjects"></param>
        /// <returns></returns>
        Task<bool> Update(object operateAnonymousObjects);

        /// <summary>
        /// 根据model，更新，指定列
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");

        /// <summary>
        /// SQL语句更新，带参数
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<bool> Update(string strSql, SugarParameter[] parameters = null);

        /// <summary>
        /// 按查询条件更新
        /// </summary>
        /// <param name="where"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        Task<bool> Update(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> columns);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entityList"></param>
        /// <returns></returns>
        Task<bool> Update(List<TEntity> entityList);

        #endregion

        #region 删除

        /// <summary>
        /// 根据id 删除某一实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteById(object id);

        /// <summary>
        /// 根据对象，删除某一实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Delete(TEntity model);

        /// <summary>
        /// 根据id数组，删除实体list
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteByIds(object[] ids);

        #endregion


        #region 查询

        /// <summary>
        /// 根据Id查询实体
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        Task<TEntity> QueryById(object objId);
        Task<TEntity> QueryById(object objId, bool blnUseCache = false);
        /// <summary>
        /// 根据id数组查询实体list
        /// </summary>
        /// <param name="lstIds"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryByIDs(object[] lstIds);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> QueryAll();

        /// <summary>
        /// 带sql where查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        Task<List<TEntity>> Query(string strWhere);

        /// <summary>
        /// 根据表达式查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);


        /// <summary>
        /// 根据条件，获得一条数据
        /// </summary>
        /// <param name="where">Expression<Func<T, bool>></param>
        /// <returns></returns>
        Task<TEntity> QuerySingle(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 根据表达式，指定返回对象模型，查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression);

        /// <summary>
        /// 根据表达式，指定返回对象模型，排序，查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <param name="whereExpression"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<List<TResult>> Query<TResult>(Expression<Func<TEntity, TResult>> expression, Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);
        Task<List<TEntity>> QuerySql(string strSql, SugarParameter[] parameters = null);
        Task<DataTable> QueryTable(string strSql, SugarParameter[] parameters = null);

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);



        /// <summary>
        /// 2表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<List<TResult>> QueryMuch<T, T2, TResult>(Expression<Func<T, T2, object[]>> joinExpression, Expression<Func<T, T2, TResult>> selectExpression, Expression<Func<T, T2, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 1表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<List<TResult>> QueryMuch<T, T2, T3, TResult>(Expression<Func<T, T2, T3, object[]>> joinExpression, Expression<Func<T, T2, T3, TResult>> selectExpression, Expression<Func<T, T2, T3, bool>> whereLambda = null) where T : class, new();


        /// <summary>
        /// 4表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<List<TResult>> QueryMuch<T, T2, T3, T4, TResult>(Expression<Func<T, T2, T3, T4, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, bool>> whereLambda = null) where T : class, new();


        /// <summary>
        /// 5表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>

        Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, TResult>(Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 6表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
      //  Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5,T6, TResult>(Expression<Func<T, T2, T3, T4, T5,T6, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5,T6, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5,T6, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 7表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
       // Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6,T7, TResult>(Expression<Func<T, T2, T3, T4, T5, T6,T7, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6,T7, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6,T7, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 8表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
       // Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7,T8, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8,object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7,T8, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7,T8, bool>> whereLambda = null) where T : class, new();


        /// <summary>
        /// 9表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
      //  Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9,TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 10表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
       // Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9,T10, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9,T10, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9,T10, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9,T10, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 11表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
       // Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10,T11, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10,T11, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10,T11, bool>> whereLambda = null) where T : class, new();

        /// <summary>
        /// 12表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
      //  Task<List<TResult>> QueryMuch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12,TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,T12, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11,T12, bool>> whereLambda = null) where T : class, new();
        /// <summary>
        /// 13表联查
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <typeparam name="T9"></typeparam>
        /// <typeparam name="T10"></typeparam>
        /// <typeparam name="T11"></typeparam>
        /// <typeparam name="T12"></typeparam>
        /// <typeparam name="T13"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
       // Task<List<TResult>> QueryMuch<T, T2, T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> selectExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> whereLambda = null) where T : class, new();



        /// <summary>
        /// 根据表达式，排序字段，分页查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<PagedModel<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);


        /// <summary>
        /// 2表联查-分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<PagedModel<TResult>> QueryTabsPage<T, T2, TResult>(Expression<Func<T, T2, object[]>> joinExpression, Expression<Func<T, T2, TResult>> selectExpression, Expression<Func<T,T2, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        Task<PagedModel<TResult>> QueryTabsPage<T, T2, T3, TResult>(Expression<Func<T, T2, T3, object[]>> joinExpression, Expression<Func<T, T2, T3, TResult>> selectExpression, Expression<Func<T,T2,T3, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);
        Task<PagedModel<TResult>> QueryTabsPage<T, T2, T3, T4, TResult>(Expression<Func<T, T2, T3, T4, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        Task<PagedModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5, TResult>(Expression<Func<T, T2, T3, T4, T5, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        //Task<PageModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5,T6, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        //Task<PageModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5, T6,T7, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        //Task<PageModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5, T6, T7,T8, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        //Task<PageModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5, T6, T7, T8,T9, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        //Task<PageModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5, T6, T7, T8, T9,T10, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);
        //Task<PageModel<TResult>> QueryTabsPage<T, T2, T3, T4, T5, T6, T7, T8, T9, T10,T11, TResult>(Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object[]>> joinExpression, Expression<Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        /// <summary>
        /// 两表联合查询-分页-分组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="joinExpression"></param>
        /// <param name="selectExpression"></param>
        /// <param name="whereExpression"></param>
        /// <param name="groupExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <param name="strOrderByFileds"></param>
        /// <returns></returns>
        Task<PagedModel<TResult>> QueryTabsPage<T, T2, TResult>(Expression<Func<T, T2, object[]>> joinExpression, Expression<Func<T, T2, TResult>> selectExpression, Expression<Func<TResult, bool>> whereExpression, Expression<Func<T, object>> groupExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        #endregion


    }
}
