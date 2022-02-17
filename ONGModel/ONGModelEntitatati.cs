using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ONGModel
{
    public partial class ONGModelEntitatati : DbContext
    {
        public ONGModelEntitatati()
            : base("name=ONGModelEntitatati")
        {
        }

        public virtual DbSet<Eveniment> Eveniments { get; set; }
        public virtual DbSet<Sediu> Sedius { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sediu>()
                .Property(e => e.Adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Sponsor>()
                .Property(e => e.Adresa)
                .IsUnicode(false);
        }
    }
}
