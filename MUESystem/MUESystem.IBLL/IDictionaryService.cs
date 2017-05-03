using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MUESystem.Model;

namespace MUESystem.IBLL
{
    public interface IDictionaryService:IBaseService<Dictionary>
    {
        bool Exist(Expression<Func<Dictionary, bool>> anyLambda);
    }
}
