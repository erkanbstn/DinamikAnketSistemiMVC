using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLayer.Abstract
{
    public interface ISirketDal : IRepositoryDal<TSirket>
    {
        List<SelectListItem> PersonelSirketi();
        TSirket SirketGiris(string kullanici, string sifre);

    }
}
