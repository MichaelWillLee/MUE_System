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
    public class DictionaryService : BaseService<Dictionary>, IDictionaryService
    {
        public DictionaryService() : base(RepositoryFactory.DictionaryRepository) { }
        public bool Exist(Expression<Func<Dictionary, bool>> anyLambda) {
            return CurrentRepository.Exist(anyLambda);
        }
    }
}
