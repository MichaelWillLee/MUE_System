using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUESystem.Model;

namespace MUESystem.DAL
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class MUEDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 字典表
        /// </summary>
        public DbSet<Dictionary> Dictionarys { get; set; }

        public MUEDbContext()
            : base("MUESystem")
        {
            Database.CreateIfNotExists();
        }
    }
}
