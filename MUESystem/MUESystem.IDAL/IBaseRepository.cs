using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.IDAL
{
    /// <summary>
    /// 接口基类
    /// </summary>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// 数据实体列表
        /// </summary>
        IQueryable<T> Entities { get; }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity, bool isSave = true);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Update(T entity, bool isSave = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity, bool isSave = true);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 查找数据【优先使用】
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>实体</returns>
        T Find(int ID);

        /// <summary>
        /// 查询数据【请优先使用Find(int ID)】
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>影响的记录数目</returns>
        int Save();
    }
}
