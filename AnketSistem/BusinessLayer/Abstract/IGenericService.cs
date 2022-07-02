using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void NesneEkle(T t);
        void NesneSil(T t);
        void NesneDuzenle(T t);
        T NesneBul(int id);
        List<T> NesneListele(int id);
        List<T> GenelListele();
    }
}
