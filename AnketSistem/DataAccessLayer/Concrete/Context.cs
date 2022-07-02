using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<TSirket> Sirkets { get; set; }
        public DbSet<TPersonel> Personels { get; set; }
        public DbSet<TAdmin> Admins { get; set; }
        public DbSet<TAnket> Ankets { get; set; }
        public DbSet<TCevap> Cevaps { get; set; }
        public DbSet<TSoru> Sorus { get; set; }
        public DbSet<TYorum> Yorums { get; set; }

    }
}
