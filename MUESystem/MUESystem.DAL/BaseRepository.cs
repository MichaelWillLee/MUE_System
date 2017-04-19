using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MUESystem.IDAL;

namespace MUESystem.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected MUEDbContext mContext = MUEDbContextFactory.GetCurrentContext();

        public IQueryable<T> Entities { get { return mContext.Set<T>(); } }

        public T Add(T entity, bool isSave = true)
        {
            mContext.Set<T>().Add(entity);
            if (isSave) mContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return mContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity, bool isSave = true)
        {
            mContext.Set<T>().Attach(entity);
            mContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return isSave ? mContext.SaveChanges() > 0 : true;
        }

        public bool Delete(T entity, bool isSave = true)
        {
            mContext.Set<T>().Attach(entity);
            mContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return isSave ? mContext.SaveChanges() > 0 : true;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return mContext.Set<T>().Any(anyLambda);
        }

        public T Find(int ID)
        {
            return mContext.Set<T>().Find(ID);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = mContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public int Save() { return mContext.SaveChanges(); }
    }
}
