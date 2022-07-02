using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TCevap
    {
        [Key]
        public int CevapID { get; set; }
        public string CevapAd { get; set; }
        public int PersonelID { get; set; }
        public virtual TPersonel Personel{ get; set; }
        public int? SoruID { get; set; }
        public virtual TSoru Soru { get; set; }
    }
}
