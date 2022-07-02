using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace DataAccessLayer.Abstract
{
    public interface IRepositoryDal<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TList();
        List<T> TIDList(Expression<Func<T,bool>>filter);
        T TGetID(Expression<Func<T,bool>>filter);
    }
}
