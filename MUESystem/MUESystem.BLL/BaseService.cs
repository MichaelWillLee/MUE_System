using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUESystem.IBLL;
using MUESystem.IDAL;

namespace MUESystem.BLL
{
    /// <summary>
    /// 服务基类
    /// <remarks></remarks>
    /// </summary>
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService(IBaseRepository<T> currentRepository) { CurrentRepository = currentRepository; }

        public T Add(T entity) { return CurrentRepository.Add(entity); }

        public bool Update(T entity) { return CurrentRepository.Update(entity); }

        public bool Delete(T entity) { return CurrentRepository.Delete(entity); }

        public T Find(int ID) { return CurrentRepository.Find(ID); }

        public IQueryable<T> PageList(IQueryable<T> entitys, int pageIndex, int pageSize)
        {
            return entitys.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
