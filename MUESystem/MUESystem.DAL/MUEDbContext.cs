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
        public DbSet<User> Users { get; set; }



        public MUEDbContext()
            : base("MUESystem")
        {
            Database.CreateIfNotExists();
        }
    }
}
