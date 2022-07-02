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
    public class AdminManager : IAdminService
    {
        IAdminDal _AdminDal;
        public AdminManager(IAdminDal AdminDal)
        {
            _AdminDal = AdminDal;
        }

        public TAdmin AdminGirisYap(string kullanici, string sifre)
        {
            return _AdminDal.AdminGiris(kullanici, sifre);
        }

        public List<TAdmin> GenelListele()
        {
            return _AdminDal.TList();
        }

        public TAdmin NesneBul(int id)
        {
            return _AdminDal.TGetID(b => b.AdminID == id);
        }

        public void NesneDuzenle(TAdmin t)
        {
            _AdminDal.TUpdate(t);
        }

        public void NesneEkle(TAdmin t)
        {
            _AdminDal.TAdd(t);
        }

        public List<TAdmin> NesneListele(int id)
        {
            return _AdminDal.TIDList(b => b.AdminID == id);
        }

        public void NesneSil(TAdmin t)
        {
            _AdminDal.TDelete(t);
        }
    }
}
