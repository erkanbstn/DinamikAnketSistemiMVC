using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class YorumManager : IYorumService
    {
        IYorumDal _YorumDal;
        public YorumManager(IYorumDal YorumDal)
        {
            _YorumDal = YorumDal;
        }
        public List<TYorum> GenelListele()
        {
            return _YorumDal.TList();
        }

        public TYorum NesneBul(int id)
        {
            return _YorumDal.TGetID(b => b.YorumID == id);
        }

        public void NesneDuzenle(TYorum t)
        {
            _YorumDal.TUpdate(t);
        }

        public void NesneEkle(TYorum t)
        {
            _YorumDal.TAdd(t);
        }

        public List<TYorum> NesneListele(int id)
        {
            return _YorumDal.TIDList(b => b.YorumID == id);
        }

        public void NesneSil(TYorum t)
        {
            _YorumDal.TDelete(t);
        }

        public int ToplamSirketYorum(int id)
        {
            return _YorumDal.ToplamYorum(id);
        }
    }
}
