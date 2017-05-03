using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUESystem.IDAL;

namespace MUESystem.DAL
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public static IUserRepository UserRepository { get { return new UserRepository(); } }

        /// <summary>
        /// 字典仓储
        /// </summary>
        public static IDictionaryRepository DictionaryRepository { get { return new DictionaryRepository(); } }
        
    }
}
