using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.IBLL
{
    /// <summary>
    /// 业务接口基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService <T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>实体</returns>
        T Find(int ID);

        /// <summary>
        /// 获取指定页数据
        /// </summary>
        /// <param name="entitys">数据实体集</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页记录数</param>
        /// <returns></returns>
        IQueryable<T> PageList(IQueryable<T> entitys, int pageIndex, int pageSize);
    }
}
