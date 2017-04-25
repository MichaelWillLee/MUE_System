using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MUESystem.DAL;
using MUESystem.IBLL;
using MUESystem.Model;

namespace MUESystem.BLL
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        public UserService() : base(RepositoryFactory.UserRepository) { }

        //public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        //{
        //    ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
        //    _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        //    _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
        //    _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
        //    _identity.AddClaim(new Claim("DisplayName", user.DisplayName));
        //    return _identity;
        //}

        public bool Exist(string userName) { return CurrentRepository.Exist(u => u.UserName == userName); }

        public bool Exist(Expression<Func<User, bool>> anyLambda) {
            return CurrentRepository.Exist(anyLambda);
        }

        public User Find(string userName) { return CurrentRepository.Find(u => u.UserName == userName); }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pageIndex">页码数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="order">排序：0-ID升序（默认），1ID降序，2注册时间升序，3注册时间降序，4登录时间升序，5登录时间降序</param>
        /// <returns></returns>
        public IQueryable<User> FindPageList(out int totalRecord, int pageIndex, int pageSize, int order)
        {
            IQueryable<User> _users = CurrentRepository.Entities;

            switch (order)
            {
                case 0:
                    _users = _users.OrderBy(c => c.ID);
                    break;
                case 1:
                    _users = _users.OrderByDescending(c => c.ID);
                    break;
                default:
                    _users = _users.OrderByDescending(c => c.ID);
                    break;
            }
            totalRecord = _users.Count();
            return PageList(_users, pageIndex, pageSize);
        }
    }
}
