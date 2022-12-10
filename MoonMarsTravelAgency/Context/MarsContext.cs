using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoonMarsTravelAgency.Models
{
    public partial class MarsContext : DbContext
    {
        public MarsContext()
            : base("name=Database")
        {
        }

        public virtual DbSet<Mars> Mars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mars>()
                .Property(e => e.Crater)
                .IsUnicode(false);

            modelBuilder.Entity<Mars>()
                .Property(e => e.LocationX)
                .IsFixedLength();

            modelBuilder.Entity<Mars>()
                .Property(e => e.LocationY)
                .IsFixedLength();

            modelBuilder.Entity<Mars>()
                .Property(e => e.Radius)
                .IsFixedLength();
        }
    }
}
