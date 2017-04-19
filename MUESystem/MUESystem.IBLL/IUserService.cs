using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUESystem.Model;

namespace MUESystem.IBLL
{
    public interface IUserService : IBaseService<User>
    {

        ///// <summary>
        ///// 创建基于声明的标识
        ///// </summary>
        ///// <param name="user">用户</param>
        ///// <param name="authenticationType">身份验证类型</param>
        ///// <returns>基于声明的标识</returns>
        //ClaimsIdentity CreateIdentity(User user, string authenticationType);

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>布尔值</returns>
        bool Exist(string userName);

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        User Find(string userName);

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pageIndex">页码数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="order">排序：0-ID升序（默认），1ID降序，2注册时间升序，3注册时间降序，4登录时间升序，5登录时间降序</param>
        /// <returns></returns>
        IQueryable<User> FindPageList(out int totalRecord, int pageIndex, int pageSize, int order);
    }
}
