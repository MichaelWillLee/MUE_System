using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUESystem.BLL
{
    /// <summary>
    /// 数据库中的状态Y,N
    /// </summary>
    public  enum  Status { Y,N};

    /// <summary>
    /// 获取Enum类中的值
    /// </summary>
    public class EnumVal {

        /// <summary>
        /// 获取Status中的值
        /// </summary>
        /// <param name="st">enum  Status</param>
        /// <returns>Y OR  N</returns>
        public static string GetStatusVal(Status st)
        {
            return st == Status.Y ? "Y" : "N";
        }
    }
}
