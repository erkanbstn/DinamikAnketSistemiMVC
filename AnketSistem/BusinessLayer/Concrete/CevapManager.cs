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
    public class CevapManager : ICevapService
    {
        ICevapDal _CevapDal;
        public CevapManager(ICevapDal CevapDal)
        {
            _CevapDal = CevapDal;
        }
        public List<TCevap> GenelListele()
        {
            return _CevapDal.TList();
        }

        public TCevap NesneBul(int id)
        {
            return _CevapDal.TGetID(b => b.CevapID == id);
        }

        public void NesneDuzenle(TCevap t)
        {
            _CevapDal.TUpdate(t);
        }

        public void NesneEkle(TCevap t)
        {
            _CevapDal.TAdd(t);
        }

        public List<TCevap> NesneListele(int id)
        {
            return _CevapDal.TIDList(b => b.CevapID == id);
        }

        public void NesneSil(TCevap t)
        {
            _CevapDal.TDelete(t);
        }

        public List<TCevap> SoruCevapListele(int id)
        {
            return _CevapDal.SoruCevapListe(id);
        }
    }
}
