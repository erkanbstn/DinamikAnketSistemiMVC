using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void TAdd(T t)
        {
            var entity = c.Entry(t);
            entity.State = EntityState.Added;
            c.SaveChanges();
            
        }

        public void TDelete(T t)
        {
            var entity = c.Entry(t);
            entity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T TGetID(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> TIDList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public List<T> TList()
        {
            return _object.ToList();
        }

        public void TUpdate(T t)
        {
            var entity = c.Entry(t);
            entity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
