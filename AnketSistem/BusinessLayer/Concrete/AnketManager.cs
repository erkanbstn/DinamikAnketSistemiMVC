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
    public class AnketManager : IAnketService
    {
        IAnketDal _AnketDal;
        public AnketManager(IAnketDal AnketDal)
        {
            _AnketDal = AnketDal;
        }
        public List<TAnket> GenelListele()
        {
            return _AnketDal.TList();
        }

        public TAnket NesneBul(int id)
        {
            return _AnketDal.TGetID(b => b.AnketID == id);
        }

        public void NesneDuzenle(TAnket t)
        {
            _AnketDal.TUpdate(t);
        }

        public void NesneEkle(TAnket t)
        {
            _AnketDal.TAdd(t);
        }

        public List<TAnket> NesneListele(int id)
        {
            return _AnketDal.TIDList(b => b.AnketID == id);
        }

        public void NesneSil(TAnket t)
        {
            _AnketDal.TDelete(t);
        }

        public List<TAnket> SirketAnketListele(int id)
        {
            return _AnketDal.SirketAnketListe(id);
        }

        public int ToplamSirketAnket(int id)
        {
            return _AnketDal.ToplamAnket(id);
        }

    }
}
