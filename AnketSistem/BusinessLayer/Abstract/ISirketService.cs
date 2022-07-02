using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer.Abstract
{
    public interface ISirketService : IGenericService<TSirket>
    {
        List<SelectListItem> DropSirket();
        TSirket SirketGirisYap(string kullanici, string sifre);

    }
}
