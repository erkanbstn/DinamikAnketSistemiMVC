using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TYorum
    {
        [Key]
        public int YorumID { get; set; }
        public string YorumAd { get; set; }
        public int PersonelID { get; set; }
        public virtual TPersonel Personel { get; set; }
    }
}
